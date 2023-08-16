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

        public MainController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Users"];
        }
        public async Task<IActionResult> Index()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if (userId != null)
            {
                var model = await _httpClient.GetFromJsonAsync<User>(_apiAddress + "/" + userId);










				return View(model);
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