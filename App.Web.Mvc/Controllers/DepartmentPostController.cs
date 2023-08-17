using App.Data.Entity;
using App.Web.Mvc.Models;
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
        public async Task<ActionResult> Create(int id) // Bu manevra bize 51 yıla mal olacak...
        {
            List<DepartmentPost> model = await _httpClient.GetFromJsonAsync<List<DepartmentPost>>(_apiAddress);

            List<DepartmentPost> viewModel = model?.Where(d => d.DepartmentId == id).ToList();

            //ViewBag.PostId = new SelectList(viewModel, "Id", "Title");
            DepartmentPostViewModel postModelView = new()
            {
                Posts = viewModel,

            };




            return View(postModelView);
        }

        // GET: DepartmentPostController/Details/5



        [HttpPost]
        public async Task<ActionResult> Create(DepartmentPostViewModel viewModel) // Bu manevra bize 51 yıla mal olacak...
        {
            try
            {


                PostComment postComment = viewModel.Comment;

              
                postComment.PostId = viewModel.Comment.PostId;
                postComment.Email = viewModel.Comment.Email;
                postComment.FullName = viewModel.Comment.FullName;
      
                postComment.Comment = viewModel.Comment.Comment;



                //List<DepartmentPost> model = await _httpClient.GetFromJsonAsync<List<DepartmentPost>>(_apiAddress);

                //List<DepartmentPost> viewModel = model?.Where(d => d.DepartmentId == id).ToList();

                //ViewBag.PostId = new SelectList(viewModel, "Id", "Title");
                int? userId = HttpContext.Session.GetInt32("userId");
                if (userId != null)
                {
                    postComment.UserId = userId;
                }

                var response = await _httpClient.PostAsJsonAsync(_apiAddressPostComments, postComment);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index", "Home");

                }
                TempData["Message"] = "<div class='alert alert-danger'>Error, Please Try Again! </div>";




                return View(postComment);
            }
            catch
            {


                ModelState.AddModelError("", "Your Comment cannot sended. Please Try Again!");
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
