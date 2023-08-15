using App.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class DoctorController : Controller
	{
        private readonly HttpClient _httpClient;
        private readonly string _apiSettingAddress;
        private readonly string _apiAddress;

        public DoctorController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiSettingAddress = rootUrl + configuration["Api:Settings"];
            _apiAddress = rootUrl + configuration["Api:Doctors"];
        }

        public async Task<IActionResult> Index()
		{
			var settings = await _httpClient.GetFromJsonAsync<List<Setting>>(_apiSettingAddress);
			var model = settings?.FirstOrDefault(s => s.IsActive);

			return View(model);
		}

        public async Task<IActionResult> Detail(int id)
        {
            //var model = await _httpClient.GetFromJsonAsync<List<Department>>(_apiAddress + "/" + id);
            List<Doctors> model = await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiAddress);

            Doctors viewModel = model?.Where(d => d.Id == id).FirstOrDefault();
            return View(viewModel);
        }
    }
}
