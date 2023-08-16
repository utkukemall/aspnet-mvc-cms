using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        //private readonly string _apiRoles;
   
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PatientController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Patients"];
            //_apiRoles = rootUrl + configuration["Api:Roles"];
           
            
        }
        // GET: PatientController
        public async Task<ActionResult> Index()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if (userId == null)
            {
                TempData["Message"] = "<div class='alert alert-danger text-center'>You should Login First! </div>";
                return RedirectToAction("Index","Home");
            }
            List<Patient> allPatients = await _httpClient.GetFromJsonAsync<List<Patient>>(_apiAddress);

            Patient mainPatient = allPatients.FirstOrDefault(p=> p.Id == userId);
            return View(mainPatient);
        }

        

        // GET: PatientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Patient collection)
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

        // GET: PatientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientController/Delete/5
       
    }
}
