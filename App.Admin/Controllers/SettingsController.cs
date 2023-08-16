using Microsoft.AspNetCore.Mvc;
using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using App.Admin.Utils;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SettingsController(HttpClient httpClient, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Settings"];
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: HomeController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Setting>>(_apiAddress);
            return View(model);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Setting collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string adminFullPath = _webHostEnvironment.WebRootPath + "\\Images\\";
                    string projectBasePath = Directory.GetParent(currentDirectory).Parent.FullName + "\\aspnet-mvc-cms\\";
                    string targetFolderPath = Path.Combine(projectBasePath, "App.Web.Mvc", "wwwroot", "Images");
                    string uiTargetFilePath = Path.Combine(targetFolderPath, Path.GetFileName(adminFullPath));

                    string adminImagePath = await FileHelper.FileLoaderAsync(Image);
                    int startIndex = adminImagePath.LastIndexOf('/') + 1;
                    string imageTitle = adminImagePath.Substring(startIndex);
                    string imagePath = await FileHelper.FileLoaderAPI(Image, targetFolderPath, imageTitle);
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
                ModelState.AddModelError("", "Error : " + e.Message);
            }
            return View(collection);
        }

        // GET: HomeController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var model = await _httpClient.GetFromJsonAsync<Setting>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Setting collection, IFormFile? Image)
        {
            if (Image is not null)
            {
                var model = await _httpClient.GetFromJsonAsync<User>(_apiAddress + "/" + id);
                bool isDeletedUI = FileHelper.FileRemover(model.Image, true, "App.Web.Mvc/wwwroot");
                bool isDeleted = FileHelper.FileRemover(model.Image, false);

                string currentDirectory = Directory.GetCurrentDirectory();
                string adminFullPath = _webHostEnvironment.WebRootPath + "\\Images\\";
                string projectBasePath = Directory.GetParent(currentDirectory).Parent.FullName + "\\aspnet-mvc-cms\\";
                string targetFolderPath = Path.Combine(projectBasePath, "App.Web.Mvc", "wwwroot", "Images");
                string uiTargetFilePath = Path.Combine(targetFolderPath, Path.GetFileName(adminFullPath));

                string adminImagePath = await FileHelper.FileLoaderAsync(Image);
                int startIndex = adminImagePath.LastIndexOf('/') + 1;
                string imageTitle = adminImagePath.Substring(startIndex);
                string imagePath = await FileHelper.FileLoaderAPI(Image, targetFolderPath, imageTitle);
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
            return View(collection);
        }

        // GET: HomeController/Delete/5
        public async Task<ActionResult> Remove(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Setting>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(int id, Setting collection)
        {
            try
            {
                var model = await _httpClient.GetFromJsonAsync<Setting>(_apiAddress + "/" + id);
                if (model.Image is not null)
                {
                    bool isDeletedUI = FileHelper.FileRemover(model.Image, true, "App.Web.Mvc/wwwroot");
                    bool isDeleted = FileHelper.FileRemover(model.Image, false);
                }
                var response = await _httpClient.DeleteAsync(_apiAddress + "/" + id);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
                }
                else
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Cannot delete the only setting available.</div>";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

