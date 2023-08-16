using App.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class DoctorController : Controller
    {
        private readonly string _apiSettingAddress;
        private readonly string _apiDoctorAddress;
        private readonly HttpClient _httpClient;

        public DoctorController(HttpClient httpClient, IConfiguration _configuration)
        {
            _httpClient = httpClient;
            var rootUrl = _configuration["Api:RootUrl"];
            _apiDoctorAddress = rootUrl + _configuration["Api:Doctors"];
        }

        public async Task<IActionResult> Index()
        {
            List<Doctors> model = await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctorAddress);

            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            List<Doctors> model = await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiDoctorAddress);

            Doctors viewModel = model?.Where(d => d.Id == id).FirstOrDefault();

            return View(viewModel);
        }
    }
}
