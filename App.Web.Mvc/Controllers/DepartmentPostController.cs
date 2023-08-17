using App.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Configuration;

namespace App.Web.Mvc.Controllers
{
    public class DepartmentPostController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly string _apiAddressPostComments;

        public DepartmentPostController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:DepartmentsPosts"];
            _apiAddressPostComments = rootUrl + configuration["Api:PostComments"];
        }

        // GET: DepartmentPostController
        public async Task<ActionResult> Index(int id) // Bu manevra bize 51 yıla mal olacak...
        {
            var model =  await _httpClient.GetFromJsonAsync<List<DepartmentPost>>(_apiAddress);

            var viewModel = model?.Where(d => d.DepartmentId == id).ToList();

            ViewBag.PostId = new SelectList(viewModel, "Id", "Title");

            return View(viewModel);
        }

        // GET: DepartmentPostController/Details/5

        [HttpPost]
        public async Task<ActionResult> Create(PostComment postComment) // Bu manevra bize 51 yıla mal olacak...
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_apiAddress, postComment);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");

                }
                TempData["Message"] = "<div class='alert alert-danger'>Error, Please Try Again! </div>";




                return View(postComment);
            }
            catch
            {


                ModelState.AddModelError("", "Your Comment cannot sended. Please Try Again!");
                return View(postComment);
            }
        }
    }
}
