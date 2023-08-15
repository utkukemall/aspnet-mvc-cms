using App.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class SubscribersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;

        public SubscribersController(HttpClient httpClient, IConfiguration _configuration)
        {
            _httpClient = httpClient;
            var rootUrl = _configuration["Api:RootUrl"];
            _apiAddress = rootUrl + _configuration["Api:Subscribers"];

        }

        // POST: SubscribersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Subscriber collection)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_apiAddress, collection);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "<div class='alert alert-success'>Thanks for Subscribing...</div>";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Message"] = "<div class='alert alert-danger'>Error, Please Try Again...</div>";
                return View(collection);
            }
            catch
            {
                return View();
            }
        }




    }
}
