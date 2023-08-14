using App.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;

namespace App.Web.Mvc.Controllers
{
    public class DepartmentPostController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress = "http://localhost:5005/api/DepartmentsPosts";
        public DepartmentPostController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: DepartmentPostController
        public async Task<ActionResult> Index(int id) // Bu manevra bize 51 yıla mal olacak...
        {
            List<DepartmentPost>? model =  await _httpClient.GetFromJsonAsync<List<DepartmentPost>>(_apiAddress);

            List<DepartmentPost>? viewModel = model.Where(d => d.DepartmentId == id).ToList();


            return View(viewModel);
        }

        // GET: DepartmentPostController/Details/5
       
    }
}
