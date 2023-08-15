using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using App.Admin.Utils;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _apiAddress;
        private readonly string _apiDepartments;
        private readonly string _apiFiles;

		public DoctorsController(HttpClient httpClient, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
		{
			_httpClient = httpClient;
			var rootUrl = configuration["Api:RootUrl"];
			_apiAddress = rootUrl + configuration["Api:Doctors"];
			_apiDepartments = rootUrl + configuration["Api:Departments"];
			_apiFiles = rootUrl + configuration["Api:File"];
			_webHostEnvironment = webHostEnvironment;
		}

		// GET: DoctorController
		public async Task<ActionResult> Index()
        {
            ViewBag.DepartmentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Department>>(_apiDepartments), "Id", "Name");
            var model = await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiAddress);
            return View(model);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.DepartmentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Department>>(_apiDepartments), "Id", "Name");
            return View();
        }

		// POST: DoctorController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Doctors collection, IFormFile Image)
        {
            try
            {
                if  (Image is not null)
                {

                    string currentDirectory = Directory.GetCurrentDirectory();

                    string adminFullPath = _webHostEnvironment.WebRootPath + "\\Images\\";

                    string projectBasePath = Directory.GetParent(currentDirectory).Parent.FullName + "\\aspnet-mvc-cms\\";

                    string targetFolderPath = Path.Combine(projectBasePath, "App.Web.Mvc", "wwwroot", "Images");

                    string uiTargetFilePath = Path.Combine(targetFolderPath, Path.GetFileName(adminFullPath));

                    string imagePath = await FileHelper.FileLoaderAPI(Image, targetFolderPath);

                    collection.Image = imagePath;

                    if (!Directory.Exists(uiTargetFilePath))
                    {
                        Directory.CreateDirectory(uiTargetFilePath);
                    }
                }

                var response = await _httpClient.PostAsJsonAsync(_apiAddress, collection);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "An error occurred: " + e.Message);
            }

            ViewBag.DepartmentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Department>>(_apiDepartments), "Id", "Name");
            return View(collection);
        }


        // GET: DoctorController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.DepartmentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Department>>(_apiDepartments), "Id", "Name");
            var model = await _httpClient.GetFromJsonAsync<Doctors>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: DoctorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Doctors collection)
        {
            var response = await _httpClient.PutAsJsonAsync(_apiAddress + "/" + id, collection);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DepartmentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Department>>(_apiDepartments), "Id", "Name");
            return View(collection);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                await _httpClient.DeleteAsync(_apiAddress + "/" + id);
                TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
