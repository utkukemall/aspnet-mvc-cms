using App.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace App.Admin.Controllers
{
    public class PagesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress = "http://localhost:5005/api/Pages";

        public PagesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: PagesController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Page>>(_apiAddress);
            return View(model);
        }

        // GET: PagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PagesController/Create
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

        // GET: PagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PagesController/Edit/5
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

        // GET: PagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PagesController/Delete/5
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
