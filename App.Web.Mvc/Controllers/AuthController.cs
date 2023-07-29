using App.Data.Entity;
using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private readonly string _apiAddress = "http://localhost:5005/api/Users";
        private readonly string _apiRoleAddress = "http://localhost:5005/api/Roles";
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User newUser, string password2)
        {
            try
            {
                if (newUser.Password == password2)
                {
                    var users = await _httpClient.GetFromJsonAsync<List<User>>(_apiAddress);
                    var user = users.FirstOrDefault(u => u.Email == newUser.Email);

                    if (user is not null)
                        ModelState.AddModelError("", "This Email Has Already Been Registered!");

                    var roles = await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress);

                    var roleFromDatabase = roles.FirstOrDefault(r => r.Id == newUser.RoleId); // newUser.RoleId Her zaman Null olduğu için roleFromDatabase de null oluyor

                    //KAAA

                    if (roleFromDatabase == null)
                    {
                        roleFromDatabase = new Role
                        {
                            RoleName = "DefaultRoleName" // roleFromDatabase Null olduğu için her zaman DefaultRoleName adında yeni role ekliyor.
                        };
                    }

                    newUser.Role = roleFromDatabase; 

                    var add = await _httpClient.PostAsJsonAsync(_apiAddress, newUser);

                    if (add.IsSuccessStatusCode)
                        return RedirectToAction("Index", "Home");
                    else
                        ModelState.AddModelError("", "An error occurred while registering the user.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(newUser);
        }






        public IActionResult Login(string redirectUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            var users = await _httpClient.GetFromJsonAsync<List<User>>(_apiAddress);
            var user = users.FirstOrDefault(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
            if (user is not null)
                return RedirectToAction("Index", "Home");
            ModelState.AddModelError("", "?");
            return View(loginModel);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
