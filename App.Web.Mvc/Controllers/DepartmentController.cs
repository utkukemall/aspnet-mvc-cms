using App.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly string _apiSettingAddress;

        public DepartmentController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Departments"];
            _apiSettingAddress = rootUrl + configuration["Api:Settings"];
        }

        public async Task<IActionResult> Index(int id, int page)
        {
            //var model = await _httpClient.GetFromJsonAsync<List<Department>>(_apiAddress);

			var settings = await _httpClient.GetFromJsonAsync<List<Setting>>(_apiSettingAddress);
			var model = settings?.FirstOrDefault(s => s.IsActive);

			return View(model);
        }


        public async Task<IActionResult> Detail(int id)
        {
            //var model = await _httpClient.GetFromJsonAsync<List<Department>>(_apiAddress + "/" + id);
            List<Department> model = await _httpClient.GetFromJsonAsync<List<Department>>(_apiAddress);

            Department viewModel = model?.Where(d => d.Id == id).FirstOrDefault();
            return View(viewModel);
        }
        
    }
}
