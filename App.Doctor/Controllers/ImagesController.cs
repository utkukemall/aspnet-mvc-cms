using App.Admin.Utils;
using App.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class ImagesController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiAddress = "http://localhost:5005/api/Images";
        public ImagesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: ImagesController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Image>>(_apiAddress);
            return View(model);
        }

        // GET: ImagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Image collection, IFormFile? ImagePath)
        {
            try
            {
                if (ImagePath != null)
                {
                    collection.ImagePath = await FileHelper.FileLoaderAsync(ImagePath);
                }

                var response = await _httpClient.PostAsJsonAsync(_apiAddress, collection);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Error!");
            }
                return View(collection);
        }

        // GET: ImagesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Image model = await _httpClient.GetFromJsonAsync<Image>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: ImagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Image collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImagesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
