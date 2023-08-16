using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using App.Admin.Utils;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PatientsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly string _apiRoles;
        private readonly string _apiDoctorsRoles;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PatientsController(HttpClient httpClient, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Patients"];
            _apiRoles = rootUrl + configuration["Api:Roles"];
            _apiDoctorsRoles = rootUrl + configuration["Api:Doctors"];
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: PatientsController
        public async Task<ActionResult> Index()
        {
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctorsRoles), "Id", "FullName");
            var model = await _httpClient.GetFromJsonAsync<List<Patient>>(_apiAddress);
            return View(model);
        }

        // GET: PatientsController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctorsRoles), "Id", "FullName");
            return View();
        }

        // POST: PatientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Patient collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string adminFullPath = _webHostEnvironment.WebRootPath + "\\Images\\";
                    string projectBasePath = Directory.GetParent(currentDirectory).Parent.FullName + "\\aspnet-mvc-cms\\";
                    string targetFolderPath = Path.Combine(projectBasePath, "App.Web.Mvc", "wwwroot", "Images");
                    string DoctorFolderPath = Path.Combine(projectBasePath, "App.Doctor", "wwwroot", "Images");
                    string uiTargetFilePath = Path.Combine(targetFolderPath, Path.GetFileName(adminFullPath));
                    string DoctorTargetFilePath = Path.Combine(DoctorFolderPath, Path.GetFileName(adminFullPath));

                    string adminImagePath = await FileHelper.FileLoaderAsync(Image);
                    int startIndex = adminImagePath.LastIndexOf('/') + 1;
                    string imageTitle = adminImagePath.Substring(startIndex);
                    string imagePath = await FileHelper.FileLoaderAPI(Image, targetFolderPath, imageTitle);
                    string doctorimagePath = await FileHelper.FileLoaderDoctor(Image, DoctorFolderPath, imageTitle);
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


            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctorsRoles), "Id", "FullName");
            return View(collection);
        }

        // GET: PatientsController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctorsRoles), "Id", "FullName");
            var model = await _httpClient.GetFromJsonAsync<Patient>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: PatientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Patient collection, IFormFile? Image)
        {
            if (Image is not null)
            {
                var model = await _httpClient.GetFromJsonAsync<Doctors>(_apiAddress + "/" + id);
                bool isDeletedUI = FileHelper.FileRemover(model.Image, true, "App.Web.Mvc/wwwroot");
                bool isDeletedDoctor = FileHelper.FileRemover(model.Image, true, "App.Doctor/wwwroot");
                bool isDeleted = FileHelper.FileRemover(model.Image, false);

                string currentDirectory = Directory.GetCurrentDirectory();
                string adminFullPath = _webHostEnvironment.WebRootPath + "\\Images\\";
                string projectBasePath = Directory.GetParent(currentDirectory).Parent.FullName + "\\aspnet-mvc-cms\\";
                string targetFolderPath = Path.Combine(projectBasePath, "App.Web.Mvc", "wwwroot", "Images");
                string DoctorFolderPath = Path.Combine(projectBasePath, "App.Doctor", "wwwroot", "Images");
                string uiTargetFilePath = Path.Combine(targetFolderPath, Path.GetFileName(adminFullPath));
                string DoctorTargetFilePath = Path.Combine(DoctorFolderPath, Path.GetFileName(adminFullPath));

                string adminImagePath = await FileHelper.FileLoaderAsync(Image);
                int startIndex = adminImagePath.LastIndexOf('/') + 1;
                string imageTitle = adminImagePath.Substring(startIndex);
                string imagePath = await FileHelper.FileLoaderAPI(Image, targetFolderPath, imageTitle);
                string doctorimagePath = await FileHelper.FileLoaderDoctor(Image, DoctorFolderPath, imageTitle);
                collection.Image = imagePath;

                if (!Directory.Exists(uiTargetFilePath))
                {
                    Directory.CreateDirectory(uiTargetFilePath);
                }
            }
            var response = await _httpClient.PutAsJsonAsync(_apiAddress + "/" + id, collection);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctorsRoles), "Id", "FullName");
            return View(collection);
        }

        // GET: PatientsController/Delete/5
        public async Task<ActionResult> Remove(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Patient>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: PatientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(int id, Patient collection)
        {
            try
            {
                var model = await _httpClient.GetFromJsonAsync<Patient>(_apiAddress + "/" + id);
                if (model.Image is not null)
                {
                    bool isDeletedUI = FileHelper.FileRemover(model.Image, true, "App.Web.Mvc/wwwroot");
                    bool isDeleted = FileHelper.FileRemover(model.Image, false);
                }
                await _httpClient.DeleteAsync(_apiAddress + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
