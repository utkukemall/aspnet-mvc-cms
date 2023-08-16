using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class DischargedPatientsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
    
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DischargedPatientsController(HttpClient httpClient, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Patients"];
 
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ActionResult> Index()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            //ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles), "Id", "RoleName");
            //ViewBag.DoctorId = new SelectList(await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctors), "Id", "FullName");
            var allPatients = await _httpClient.GetFromJsonAsync<List<Patient>>(_apiAddress);
            var doctorsPatients = allPatients?.Where(p => p.DoctorId == userId && p.IsDischarged).ToList();

            return View(doctorsPatients);
        }
    }
}
