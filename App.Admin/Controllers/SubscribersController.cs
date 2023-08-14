using App.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
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

        // GET: SubscribbersController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Subscriber>>(_apiAddress);
            return View(model);
        }
       
    }
}
