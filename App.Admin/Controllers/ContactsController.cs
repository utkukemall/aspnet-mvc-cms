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

        private readonly string _apiAddress = "http://localhost:5005/api/Contacts";

        public ContactsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
