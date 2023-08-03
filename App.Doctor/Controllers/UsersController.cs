﻿using App.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress = "http://localhost:5005/api/Users";
        private readonly string _apiRoleAddress = "http://localhost:5005/api/Roles";
        private readonly string _apiImageAddress = "http://localhost:5005/api/Images";

        public UsersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress), "Id", "RoleName");
            ViewBag.ImageId = new SelectList(await _httpClient.GetFromJsonAsync<List<Image>>(_apiImageAddress), "Id", "ImageTitle");
            var model = await _httpClient.GetFromJsonAsync<List<Patient>>(_apiAddress);
            return View(model);
        }

        // GET: UsersController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: UsersController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress), "Id", "RoleName");
            ViewBag.ImageId = new SelectList(await _httpClient.GetFromJsonAsync<List<Image>>(_apiImageAddress), "Id", "ImageTitle");
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(User collection)
        //{
        //    try
        //    {
        //        var users = await _httpClient.GetFromJsonAsync<List<User>>(_apiAddress);
        //        var user = users.FirstOrDefault(u => u.Email == collection.Email);

        //        if (user is not null)
        //            ModelState.AddModelError("", "This Email Has Already Been Registered!");

        //        var roles = await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress);

        //        var roleFromDatabase = roles.FirstOrDefault(r => r.Id == collection.RoleId); // newUser.RoleId Her zaman Null olduğu için roleFromDatabase de null oluyor

        //        //KAAA

        //        if (roleFromDatabase == null)
        //        {
        //            roleFromDatabase = new Role
        //            {
        //                RoleName = "KadirAltınay" // roleFromDatabase Null olduğu için her zaman DefaultRoleName adında yeni role ekliyor.
        //            };
        //        }

        //        collection.Role = roleFromDatabase;

        //        var response = await _httpClient.PostAsJsonAsync(_apiAddress, collection);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    catch
        //    {
        //        ModelState.AddModelError("", "An error occurred while registering the user.");
        //    }
        //    return View(collection);
        //}

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
                ModelState.AddModelError("", "Hata oluştu : " + e.Message);
            }
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress), "Id", "RoleName");
            ViewBag.ImageId = new SelectList(await _httpClient.GetFromJsonAsync<List<Image>>(_apiImageAddress), "Id", "ImageTitle");
            return View(collection);
        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress), "Id", "RoleName");
            ViewBag.ImageId = new SelectList(await _httpClient.GetFromJsonAsync<List<Image>>(_apiImageAddress), "Id", "ImageTitle");
            var model = await _httpClient.GetFromJsonAsync<User>(_apiAddress + "/" + id);
            return View(model);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, User collection)
        {
            var response = await _httpClient.PutAsJsonAsync<User>((_apiAddress + "/" + id), collection);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
            }
            ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress), "Id", "RoleName");
            ViewBag.ImageId = new SelectList(await _httpClient.GetFromJsonAsync<List<Image>>(_apiImageAddress), "Id", "ImageTitle");
            return RedirectToAction(nameof(Index));
        }

        // GET: UsersController/Delete/5
        public ActionResult Remove(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id, IFormCollection collection)
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
