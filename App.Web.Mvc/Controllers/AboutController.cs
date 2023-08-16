using App.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class AboutController : Controller
    {
       
        private readonly string _apiAddressSubscriber;
        private readonly HttpClient _httpClient;

        public AboutController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddressSubscriber = rootUrl + configuration["Api:Subscribers"];

        }

        public async Task<IActionResult> Create()
        {
           
            return View();
        }

		[HttpPost]
		public async Task<ActionResult> Create(Subscriber collection)
		{
			try
			{
				var response = await _httpClient.PostAsJsonAsync(_apiAddressSubscriber, collection);
				if (response.IsSuccessStatusCode)
				{
					TempData["Message"] = "<div class='alert alert-success text-center'>The Job is Done Sir!</div>";
					return RedirectToAction(nameof(Create));

				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("", "Error! : " + e.Message);
			}
			return View(collection);
		}
	}
}
