using App.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class ServicesController : Controller
	{
        private readonly HttpClient _httpClient;
        private readonly string _apiSettingAddress;

        public ServicesController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiSettingAddress = rootUrl + configuration["Api:Settings"];
        }

        public async Task<IActionResult> Index()
		{
			var settings = await _httpClient.GetFromJsonAsync<List<Setting>>(_apiSettingAddress);
			var model = settings?.FirstOrDefault(s => s.IsActive);
			return View(model);
		}
	}
}
