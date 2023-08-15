using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using App.Data.Entity;
using App.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MainController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAddress;
        private readonly string _apiAppointments;
        private readonly string _apiContacts;
        private readonly string _apiDepartments;
        private readonly string _apiDepartmentsPosts;
        private readonly string _apiPosts;
        private readonly string _apiSubscribers;
        private readonly string _apiPostComments;
        private readonly string _apiRoles;
        private readonly string _apiSettings;

        public MainController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var rootUrl = configuration["Api:RootUrl"];
            _apiAddress = rootUrl + configuration["Api:Users"];
            _apiAppointments = rootUrl + configuration["Api:Appointments"];
            _apiContacts = rootUrl + configuration["Api:Contacts"];
            _apiDepartments = rootUrl + configuration["Api:Departments"];
            _apiDepartmentsPosts = rootUrl + configuration["Api:DepartmentsPosts"];
            _apiPosts = rootUrl + configuration["Api:Posts"];
            _apiSubscribers = rootUrl + configuration["Api:Subscribers"];
            _apiPostComments = rootUrl + configuration["Api:PostComments"];
            _apiRoles = rootUrl + configuration["Api:Roles"];
            _apiSettings = rootUrl + configuration["Api:Settings"];
        }

        public async Task<IActionResult> Index()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if (userId != null)
            {
                // Fetch user count
                var userslist = await _httpClient.GetFromJsonAsync<List<User>>(_apiAddress);
                int? doctorCount = userslist?.Where(d => d.RoleId == 2).Count();
                int? patientCount = userslist?.Where(d => d.RoleId == 3).Count();
                int? userCount = userslist?.Where(d => d.RoleId == 4).Count();

                // Fetch appointment count
                var appointmentsList = await _httpClient.GetFromJsonAsync<List<Appointment>>(_apiAppointments);
                int? appointmentCount = appointmentsList?.Count;

                // Fetch contact count
                var contactsList = await _httpClient.GetFromJsonAsync<List<Contact>>(_apiContacts);
                int? contactCount = contactsList?.Count;

                // Fetch department count
                var departmentsList = await _httpClient.GetFromJsonAsync<List<Department>>(_apiDepartments);
                int? departmentCount = departmentsList?.Count;

                // Fetch departments posts count
                var departmentsPostsList = await _httpClient.GetFromJsonAsync<List<DepartmentPost>>(_apiDepartmentsPosts);
                int? departmentsPostsCount = departmentsPostsList?.Count;

                // Fetch post count
                var postsList = await _httpClient.GetFromJsonAsync<List<Post>>(_apiPosts);
                int? postCount = postsList?.Count;

                // Fetch subscriber count
                var subscribersList = await _httpClient.GetFromJsonAsync<List<Subscriber>>(_apiSubscribers);
                int? subscriberCount = subscribersList?.Count;

                // Fetch post comments count
                var postCommentsList = await _httpClient.GetFromJsonAsync<List<PostComment>>(_apiPostComments);
                int? postCommentsCount = postCommentsList?.Count;

                // Fetch role count
                var rolesList = await _httpClient.GetFromJsonAsync<List<Role>>(_apiRoles);
                int? roleCount = rolesList?.Count;

                // Fetch settings count
                var settingsList = await _httpClient.GetFromJsonAsync<List<Setting>>(_apiSettings);
                int? settingsCount = settingsList?.Count;

                // Pass the counts to the view
                var viewModel = new DashboardViewModel
                {
                    DoctorCount = doctorCount,
                    PatientCount = patientCount,
                    UserCount = userCount,
                    AppointmentCount = appointmentCount,
                    ContactCount = contactCount,
                    DepartmentCount = departmentCount,
                    DepartmentsPostsCount = departmentsPostsCount,
                    PostCount = postCount,
                    SubscriberCount = subscriberCount,
                    PostCommentsCount = postCommentsCount,
                    RoleCount = roleCount,
                    SettingsCount = settingsCount
                };

                return View(viewModel);
            }

            return RedirectToAction("Logout", "Auth");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}