using App.Data.Entity;
using App.Web.Mvc.ViewComponents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Drawing2D;

namespace App.Admin.Controllers
{
    public class DepartmentPostsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress = "http://localhost:5005/api/DepartmentsPosts";
        private readonly string _apiDepartments = "http://localhost:5005/api/Departments";
        public DepartmentPostsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: DepartmentPostsController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<DepartmentPost>>(_apiAddress);
            return View(model);
        }

        //GET: DepartmentPostsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentPostsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentPostsController/Createz
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(DepartmentPost collection)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_apiAddress, collection);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            ViewBag.DepartmentId = new SelectList(await _httpClient.GetFromJsonAsync<List<DepartmentPost>>(_apiDepartments), "Id", "Name");
            return View();
        }

        // GET: DepartmentPostsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentPostsController/Edit/5
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

        // GET: DepartmentPostsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentPostsController/Delete/5
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
