using App.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class PostCommentsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress = "http://localhost:5005/api/PostComments";
        public PostCommentsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: PostCommentsController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<PostComment>>(_apiAddress);
            return View(model);
        }

        // GET: PostCommentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostCommentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostCommentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostCommentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostCommentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostCommentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostCommentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
