using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;

        public ContactsController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Contacts"];
        }

        // GET: ContactsController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Contact>>(_apiAddress);
            return View(model);
        }       


        // POST: ContactsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(int id, IFormCollection collection)
        {
            try
            {
                await _httpClient.DeleteAsync(_apiAddress + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
