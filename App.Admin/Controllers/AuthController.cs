﻿using App.Admin.Models;
using App.Admin.Utils;
using App.Data.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.Admin.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly string _apiRoleAddress;

        public AuthController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Users"];
            _apiRoleAddress = rootUrl + configuration["Api:Roles"];
        }



        //public IActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]


        //public async Task<IActionResult> Register(User newUser, string password2)
        //{
        //    try
        //    {
        //        if (newUser.Password == password2)
        //        {
        //            var users = await _httpClient.GetFromJsonAsync<List<User>>(_apiAddress);
        //            var user = users.FirstOrDefault(u => u.Email == newUser.Email);

        //            if (user is not null)
        //                ModelState.AddModelError("", "This Email Has Already Been Registered!");

        //            var roles = await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress);

        //            // Burada, doktor, kullanıcı ve admin rollerinden birini seçelim.
        //            Role selectedRole = SelectRoleToAssign(roles);

        //            if (selectedRole == null)
        //            {
        //                ModelState.AddModelError("", "No valid role found to assign to the new user.");
        //                return View(newUser);
        //            }

        //            newUser.RoleId = selectedRole.Id; // Eğer Id kullanıyorsanız RoleId'ye atayın, ya da RoleName'e göre yapıyorsanız RoleName'e atayın.

        //            var add = await _httpClient.PostAsJsonAsync(_apiAddress, newUser);

        //            if (add.IsSuccessStatusCode)
        //                return RedirectToAction("Main", "Home");
        //            else
        //                ModelState.AddModelError("", "An error occurred while registering the user.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //    }
        //    return View(newUser);
        //}

        // Belirtilen üç rol (doktor, kullanıcı ve admin) arasından birini seçen yardımcı fonksiyon.
        //private Role SelectRoleToAssign(List<Role> roles)
        //{

        //    // Varsayılan olarak, doktor rolünü döndürelim:
        //    return roles.FirstOrDefault(r => r.RoleName == "doktor");
        //}


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login),"Auth");
        }




        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            var users = await _httpClient.GetFromJsonAsync<List<User>>(_apiAddress);
            var account = users.Where(x => x.Email == loginModel.Email && x.Password == loginModel.Password).FirstOrDefault();

            if (account == null)
            {

                ModelState.AddModelError("", "Login Failed!");
                TempData["Message"] = "<div class='alert alert-danger'>Login Failed!</div>";

                return View(loginModel);
            }
            else
            {

                if (account.RoleId == 1)
                {
                    var userAccess = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, account.Email),
                        new Claim(ClaimTypes.Role, "Admin")

                    };

                    var userIdentity = new ClaimsIdentity(userAccess, "Login");


                    ClaimsPrincipal claimsPrincipal = new(userIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetInt32("userId", account.Id);

                    return RedirectToAction("Index","Main");
                }
                else
                {
                    ModelState.AddModelError("", "You have not permitted!");
                    TempData["Message"] = "<div class='alert alert-danger'>You have not permitted!</div>";
                    return View(loginModel);
                }


            }

        }


        public async Task<IActionResult> UpdateUser()
        {
            try
            {
                var userId = HttpContext.Session.GetInt32("userId");

                User? account = await _httpClient.GetFromJsonAsync<User>(_apiAddress + "/" + userId);

                return View(account);
            }
            catch (Exception)
            {
            }
            TempData["Message"] = "<div class='alert alert-danger'>You have to log out first!</div>";
            return RedirectToAction("Index", "Main");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    user.Image = await FileHelper.FileLoaderAsync(Image);
                }

                var userId = HttpContext.Session.GetInt32("userId");

                User? account = await _httpClient.GetFromJsonAsync<User>(_apiAddress + "/" + userId);

                if (account!= null)
                {
                    if (ModelState.IsValid)
                    {
                        var response = await _httpClient.PutAsJsonAsync(_apiAddress + "/" + userId, user);

                        if (response.IsSuccessStatusCode)
                        {
                            TempData["Message"] = "<div class='alert alert-success' >Account Updated successfully... </div>";

                            return RedirectToAction("Index", "Main");
                        }

                    }                  
                }
            }
            catch (Exception e)
            {

            }
                ModelState.AddModelError("", "Update Failed");
            return View("UpdateUser",user);
        }
    }
}
