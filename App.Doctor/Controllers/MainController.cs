using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using App.Data.Entity;
using App.Doctor.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Net.Http;

namespace App.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    //deneme
    public class MainController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly string _apiPatients;
        private readonly string _apiAppointments;

        public MainController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Users"];
            _apiPatients = rootUrl + configuration["Api:Patients"];
            _apiAppointments = rootUrl + configuration["Api:Appointments"];
        }
        public async Task<IActionResult> Index()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if (userId != null)
            {
                var model = await _httpClient.GetFromJsonAsync<User>(_apiAddress + "/" + userId);

                var Patientslist = await _httpClient.GetFromJsonAsync<List<Patient>>(_apiPatients);
                int? patientCount = Patientslist?.Where(p => p.DoctorId == userId && !p.IsDischarged).Count();
                int? patientDCount = Patientslist?.Where(p => p.IsDischarged && p.DoctorId == userId).Count();

                var appointmentsList = await _httpClient.GetFromJsonAsync<List<Appointment>>(_apiAppointments);
                int? appointmentCount = appointmentsList?.Where(p => p.DoctorId == userId).Count();


                var viewModel = new DoctorViewModel
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Role = "Doctor",
                    PatientCount = (int)patientCount,
                    DischargedPatientCount = (int)patientDCount,
                    AppointmentCount = (int)appointmentCount,
                };
                return View(viewModel);
            }
            return RedirectToAction("Logout", "Auth");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}