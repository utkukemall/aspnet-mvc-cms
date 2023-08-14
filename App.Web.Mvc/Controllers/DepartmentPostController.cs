using App.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;

namespace App.Web.Mvc.Controllers
{
    public class DepartmentPostController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;

        public DepartmentPostController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:DepartmentsPosts"];
        }

        // GET: DepartmentPostController
        public async Task<ActionResult> Index(int id) // Bu manevra bize 51 yıla mal olacak...
        {
            var model =  await _httpClient.GetFromJsonAsync<List<DepartmentPost>>(_apiAddress);

            var viewModel = model?.Where(d => d.DepartmentId == id).ToList();


            return View(viewModel);
        }

        // GET: DepartmentPostController/Details/5
       
    }
}
