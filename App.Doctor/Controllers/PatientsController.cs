using App.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Admin.Controllers
{
    public class PatientsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress = "http://localhost:5005/api/Patients";
        private readonly string _apiRoles = "http://localhost:5005/api/Roles";
        private readonly string _apiDoctorsRoles = "http://localhost:5005/api/Doctors";
        public PatientsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: PatientsController
        public async Task<ActionResult> Index()
        {
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctorsRoles), "Id", "FullName");
            var model = await _httpClient.GetFromJsonAsync<List<Patient>>(_apiAddress);
            return View(model);
        }

        // GET: PatientsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

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
        public async Task<ActionResult> Create(Patient collection)
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
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctorsRoles), "Id", "FullName");
            return View(collection);
        }

        // GET: PatientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientsController/Edit/5
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

        // GET: PatientsController/Delete/5
        public ActionResult Remove(int id)
        {
            return View();
        }

        // POST: PatientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id, IFormCollection collection)
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
