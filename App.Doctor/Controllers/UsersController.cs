using App.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress = "http://localhost:5005/api/Users";
        private readonly string _apiRoleAddress = "http://localhost:5005/api/Roles";

        public UsersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<User>>(_apiAddress);
            return View(model);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User collection)
        {
            try
            {
                var users = await _httpClient.GetFromJsonAsync<List<User>>(_apiAddress);
                var user = users.FirstOrDefault(u => u.Email == collection.Email);

                if (user is not null)
                    ModelState.AddModelError("", "This Email Has Already Been Registered!");

                var roles = await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoleAddress);

                var roleFromDatabase = roles.FirstOrDefault(r => r.Id == collection.RoleId); // newUser.RoleId Her zaman Null olduğu için roleFromDatabase de null oluyor

                //KAAA

                if (roleFromDatabase == null)
                {
                    roleFromDatabase = new Role
                    {
                        RoleName = "KadirAltınay" // roleFromDatabase Null olduğu için her zaman DefaultRoleName adında yeni role ekliyor.
                    };
                }

                collection.Role = roleFromDatabase;

                var response = await _httpClient.PostAsJsonAsync(_apiAddress, collection);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while registering the user.");
            }
            return View(collection);
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
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

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
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
