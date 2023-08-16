using App.Data.Entity;
using App.Web.Mvc.Models;
using App.Web.Mvc.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace App.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly string _apiRoleAddress;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AuthController(HttpClient httpClient, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Users"];
            _apiRoleAddress = rootUrl + configuration["Api:Roles"];
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Register()
        {
            //ViewBag.RoleId = new SelectList(await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress), "Id", "RoleName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser, IFormFile? Image)
        {
            try
            {
                List<User> users = await _httpClient.GetFromJsonAsync<List<User>>(_apiAddress);
                var existingUser = users.FirstOrDefault(u => u.Email == newUser.Email);

                if (existingUser == null)
                {
                    //var roles = await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress);

                    //// "User" rolünü seçelim.
                    //Role selectedRole = roles.FirstOrDefault(r => r.RoleName == "User");

                    //if (selectedRole == null)
                    //{
                    //    ModelState.AddModelError("", "No valid role found to assign to the new user.");
                    //    return View(newUser);
                    //}

                    newUser.RoleId = 4;

                    var addUserResponse = await _httpClient.PostAsJsonAsync(_apiAddress, newUser);

                    if (!addUserResponse.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError("", "An error occurred while registering the user.");
                        return View(newUser);
                    }

                    if (Image is not null)
                    {
                        string currentDirectory = Directory.GetCurrentDirectory();
                        string webMvcFullPath = _webHostEnvironment.WebRootPath + "\\Images\\";
                        string projectBasePath = Directory.GetParent(currentDirectory).Parent.FullName + "\\aspnet-mvc-cms\\";
                        string targetFolderPath = Path.Combine(projectBasePath, "App.Admin", "wwwroot", "Images");
                        string doctorFolderPath = Path.Combine(projectBasePath, "App.Doctor", "wwwroot", "Images");
                        string adminTargetFilePath = Path.Combine(targetFolderPath, Path.GetFileName(webMvcFullPath));
                        string doctorTargetFilePath = Path.Combine(doctorFolderPath, Path.GetFileName(webMvcFullPath));

                        string webMvcImagePath = await FileHelper.FileLoaderAsync(Image);
                        int startIndex = webMvcImagePath.LastIndexOf('/') + 1;
                        string imageTitle = webMvcImagePath.Substring(startIndex);
                        string imagePath = await FileHelper.FileLoaderAPI(Image, targetFolderPath, imageTitle);
                        string doctorImagePath = await FileHelper.FileLoaderDoctor(Image, doctorFolderPath, imageTitle);
                        newUser.Image = imagePath;

                        if (!Directory.Exists(adminTargetFilePath))
                        {
                            Directory.CreateDirectory(adminTargetFilePath);
                        }
                    }

                    TempData["Message"] = "<div class='alert alert-success'>The Job is Done Sir!</div>";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "This Email Has Already Been Registered!");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(newUser);
        }

        // Belirtilen üç rol (doktor, kullanıcı ve admin) arasından birini seçen yardımcı fonksiyon.
        private Role SelectRoleToAssign(List<Role> roles)
        {
            // Burada, belirtilen üç rol arasından birini seçmek için kendi kriterlerinize göre bir seçim yapabilirsiniz.
            // Örneğin, rastgele bir rol seçmek için aşağıdaki gibi yapabilirsiniz:
            // Random random = new Random();
            // int randomIndex = random.Next(0, roles.Count);
            // return roles[randomIndex];

            // Varsayılan olarak, doktor rolünü döndürelim:
            return roles.FirstOrDefault(r => r.RoleName == "doktor");
        }

        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Remove("userId");
                HttpContext.Session.Remove("userGuid");
            }
            catch
            {
                HttpContext.Session.Clear();
            }
            return RedirectToAction("Index", "Home");
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

                if (account.RoleId == 3)
                {
                    var userAccess = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, account.Email),
                        new Claim(ClaimTypes.Role, "Patient")

                    };

                    var userIdentity = new ClaimsIdentity(userAccess, "Login");


                    ClaimsPrincipal claimsPrincipal = new(userIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetInt32("userId", account.Id);

                    return RedirectToAction("Index", "Patient");
                }
                else
                {

                    var userAccess = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, account.Email),
                        new Claim(ClaimTypes.Role, account.Role.RoleName.ToString())

                    };

                    var userIdentity = new ClaimsIdentity(userAccess, "Login");


                    ClaimsPrincipal claimsPrincipal = new(userIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetInt32("userId", account.Id);


                    return RedirectToAction("Index", "Home");
                }


            }

        }



        public IActionResult ForgotPassword()
        {
            return View();
        }



    }
}
