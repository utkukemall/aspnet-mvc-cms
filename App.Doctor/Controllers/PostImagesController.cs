using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class PostImagesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "http://localhost:5005/api/Users";
        public PostImagesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: PostImagesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PostImagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostImagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostImagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PostImagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostImagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PostImagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostImagesController/Delete/5
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
