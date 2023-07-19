using App.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.ViewComponents
{
	public class Departments : ViewComponent
	{
		private readonly HttpClient _httpClient;

		public Departments(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}


		// Apı Adresi gelecek

		//public async Task<IViewComponentResult> InvokeAsync()
		//{
		//	List<Department> departments = await _httpClient.GetFromJsonAsync<List<Department>>("      {Apiadresi gelecek} ");
		//	return View(departments);
		//}
	}
}
