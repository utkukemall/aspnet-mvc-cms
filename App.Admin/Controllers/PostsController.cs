using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Azure;
using App.Admin.Utils;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly string _apiUsers;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostsController(HttpClient httpClient, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Posts"];
            _apiUsers = rootUrl + configuration["Api:Users"];
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: PostsController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Post>>(_apiAddress);
            return View(model);
        }

        // GET: PostsController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.UserId = new SelectList(await _httpClient.GetFromJsonAsync<List<User>>(_apiUsers), "Id", "Email");
            return View();
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Post collection, IFormFile? Image)
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
            catch
            {
                ModelState.AddModelError("", "Error");
            }
            ViewBag.UserId = new SelectList(await _httpClient.GetFromJsonAsync<List<User>>(_apiUsers), "Id", "Email");
            return View(collection);
        }

        // GET: PostsController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var model = await _httpClient.GetFromJsonAsync<Post>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Post collection, IFormFile? Image)
        {
            if (Image is not null)
            {
                var model = await _httpClient.GetFromJsonAsync<Post>(_apiAddress + "/" + id);
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

        // GET: PostsController/Delete/5
        public async Task<ActionResult> Remove(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Post>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: PostsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(int id, Post collection)
        {
            try
            {
                var model = await _httpClient.GetFromJsonAsync<Post>(_apiAddress + "/" + id);
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
                    TempData["Message"] = "<div class='alert alert-danger'>Please delete the department post first.</div>";
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
