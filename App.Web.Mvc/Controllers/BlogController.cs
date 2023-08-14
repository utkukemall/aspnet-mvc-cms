using App.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace App.Web.Mvc.Controllers
{
	public class BlogController : Controller
	{
        private readonly HttpClient _httpClient;
        private readonly string _apiSettingAddress;

        public BlogController(HttpClient httpClient, IConfiguration configuration)
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
		public async Task<IActionResult> Post(int id)
		{
			var settings = await _httpClient.GetFromJsonAsync<List<Setting>>(_apiSettingAddress);
			var model = settings?.FirstOrDefault(s => s.IsActive);

			return View(model);
		}
	}
}
