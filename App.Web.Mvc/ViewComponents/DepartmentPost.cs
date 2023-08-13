using App.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.ViewComponents
{
    public class DepartmentPost : ViewComponent
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiAddress = "http://localhost:5005/api/DepartmentsPosts";

        public DepartmentPost(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var modelView = await _httpClient.GetFromJsonAsync<List<DepartmentPost>>(_apiAddress);

            return View(modelView);
        }
    }
}
