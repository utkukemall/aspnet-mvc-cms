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
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.DepartmentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Department>>(_apiDepartments), "Id", "Name");
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
                    TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Hata oluştu : " + e.Message);
            }
            ViewBag.DepartmentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Department>>(_apiDepartments), "Id", "Name");
            return View(collection);
        }

        // GET: DepartmentPostsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ViewBag.DepartmentId = new SelectList(await _httpClient.GetFromJsonAsync<List<Department>>(_apiDepartments), "Id", "Name");
            var model = await _httpClient.GetFromJsonAsync<Department>(_apiAddress + "/" + id);
            return View(model);
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
