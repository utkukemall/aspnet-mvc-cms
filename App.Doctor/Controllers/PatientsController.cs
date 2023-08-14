using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace App.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class PatientsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly string _apiRoles;
        private readonly string _apiDoctors ;
        public PatientsController(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Patients"];
            _apiRoles = rootUrl + configuration["Api:Roles"];
            _apiDoctors = rootUrl + configuration["Api:Doctors"];
        }
        // GET: PatientsController
        public async Task<ActionResult> Index()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctors), "Id", "FullName");
            var allPatients = await _httpClient.GetFromJsonAsync<List<Patient>>(_apiAddress);
            var doctorsPatients = allPatients?.Where(p => p.DoctorId == userId).ToList();

            return View(doctorsPatients);
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
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctors), "Id", "FullName");
            return View();
        }

        // POST: PatientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Patient collection)
        {
            try
            {
                int? doctorId =  HttpContext.Session.GetInt32("userId");

                if (doctorId != null)
                {
                    collection.DoctorId = doctorId;
                }
                else
                {
                    TempData["Message"] = "<div class='alert alert-danger'>You need to Re login First...</div>";
                    return RedirectToAction(nameof(Index));
                }
                var response = await _httpClient.PostAsJsonAsync(_apiAddress, collection);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
                    return RedirectToAction(nameof(Index),"Main");

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Hata oluştu : " + e.Message);
            }
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctors), "Id", "FullName");
            return View(collection);
        }

        // GET: PatientsController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctors), "Id", "FullName");
            var model = await _httpClient.GetFromJsonAsync<Patient>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: PatientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Patient collection)
        {
            var response = await _httpClient.PutAsJsonAsync(_apiAddress + "/" + id, collection);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
            }
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctors), "Id", "FullName");
            return RedirectToAction(nameof(Index));
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
