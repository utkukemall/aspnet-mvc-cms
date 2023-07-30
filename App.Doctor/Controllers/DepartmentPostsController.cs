﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class DepartmentPostsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "http://localhost:5005/api/Users";
        public DepartmentPostsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: DepartmentPostsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DepartmentPostsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentPostsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentPostsController/Create
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

        // GET: DepartmentPostsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentPostsController/Edit/5
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

        // GET: DepartmentPostsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentPostsController/Delete/5
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