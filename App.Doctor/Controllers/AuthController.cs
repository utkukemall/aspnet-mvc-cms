using App.Doctor.Utils;
using App.Data.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using App.Doctor.Models;
using Microsoft.AspNetCore.Hosting;

namespace App.Doctor.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly string _apiUserAddress;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AuthController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Doctors"];
            _apiUserAddress = rootUrl + configuration["Api:Users"];
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login), "Auth");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            var users = await _httpClient.GetFromJsonAsync<List<Doctors>>(_apiAddress);
            var account = users?.Where(x => x.Email == loginModel.Email && x.Password == loginModel.Password).FirstOrDefault();

            if (account == null)
            {

                ModelState.AddModelError("", "Login Failed!");
                TempData["Message"] = "<div class='alert alert-danger'>Login Failed!</div>";

                return View(loginModel);
            }
            else
            {

                if (account.RoleId == 2)
                {
                    var userAccess = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, account.Email),
                        new Claim(ClaimTypes.Role, "Doctor")

                    };

                    var userIdentity = new ClaimsIdentity(userAccess, "Login");


                    ClaimsPrincipal claimsPrincipal = new(userIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetInt32("userId", account.Id);

                    return RedirectToAction("Index", "Main");
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
                int? userId = HttpContext.Session.GetInt32("userId");

                User? account = await _httpClient.GetFromJsonAsync<User>(_apiUserAddress + "/" + userId);

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
                int? userId = HttpContext.Session.GetInt32("userId");

                if (Image is not null)
                {
                    var model = await _httpClient.GetFromJsonAsync<User>(_apiAddress + "/" + userId);
                    bool isDeletedUI = FileHelper.FileRemover(model.Image, true, "App.Web.Mvc/wwwroot");
                    bool isDeletedDoctor = FileHelper.FileRemover(model.Image, true, "App.Doctor/wwwroot");
                    bool isDeleted = FileHelper.FileRemover(model.Image, false);

                    string currentDirectory = Directory.GetCurrentDirectory();
                    string DoctorFullPath = _webHostEnvironment.WebRootPath + "\\Images\\";
                    string projectBasePath = Directory.GetParent(currentDirectory).Parent.FullName + "\\aspnet-mvc-cms\\";
                    string targetFolderPath = Path.Combine(projectBasePath, "App.Web.Mvc", "wwwroot", "Images");
                    string AdminFolderPath = Path.Combine(projectBasePath, "App.Admin", "wwwroot", "Images");
                    string uiTargetFilePath = Path.Combine(targetFolderPath, Path.GetFileName(DoctorFullPath));
                    string AdminTargetFilePath = Path.Combine(AdminFolderPath, Path.GetFileName(DoctorFullPath));

                    string DoctorImagePath = await FileHelper.FileLoaderAsync(Image);
                    int startIndex = DoctorImagePath.LastIndexOf('/') + 1;
                    string imageTitle = DoctorImagePath.Substring(startIndex);
                    string imagePath = await FileHelper.FileLoaderAPI(Image, targetFolderPath, imageTitle);
                    string AdminimagePath = await FileHelper.FileLoaderAdmin(Image, AdminFolderPath, imageTitle);
                    user.Image = imagePath;

                    if (!Directory.Exists(uiTargetFilePath))
                    {
                        Directory.CreateDirectory(uiTargetFilePath);
                    }
                }

                User? account = await _httpClient.GetFromJsonAsync<User>(_apiUserAddress + "/" + userId);

                if (account != null)
                {
                    if (ModelState.IsValid)
                    {
                        var response = await _httpClient.PutAsJsonAsync(_apiUserAddress + "/" + userId, user);

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

                ModelState.AddModelError("", "Update Failed" + e.Message);
            }
            TempData["Message"] = "<div class='alert alert-danger' >Error... </div>";
            return View();
        }
    }
}
