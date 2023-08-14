using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly string _apiRoleAddress;


        public UsersController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Users"];
            _apiRoleAddress = rootUrl + configuration["Api:Roles"];
        }


        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress), "Id", "RoleName");

            var model = await _httpClient.GetFromJsonAsync<List<Patient>>(_apiAddress);
            return View(model);
        }

        // GET: UsersController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress), "Id", "RoleName");

            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User collection)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_apiAddress, collection);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error : " + e.Message);
            }
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress), "Id", "RoleName");

            return View(collection);
        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress), "Id", "RoleName");

            var model = await _httpClient.GetFromJsonAsync<User>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, User collection)
        {
            var response = await _httpClient.PutAsJsonAsync(_apiAddress + "/" + id, collection);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress), "Id", "RoleName");
            return View(collection);

        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> Remove(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<User>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(int id, User collection)
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
