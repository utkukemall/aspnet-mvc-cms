﻿using App.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.ViewComponents
{
    public class Departments : ViewComponent
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiAddress;
        public Departments(HttpClient httpClient, IConfiguration _configuration)
        {
            _httpClient = httpClient;
            var rootUrl = _configuration["Api:RootUrl"];
            _apiAddress = rootUrl + _configuration["Api:Departments"];
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Department>>(_apiAddress);
            model.OrderBy(d=> d.Name);
            return View(model);
        }
    }
}
