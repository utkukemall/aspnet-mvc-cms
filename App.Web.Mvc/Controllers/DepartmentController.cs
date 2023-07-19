using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class DepartmentController : Controller
    {
		//private readonly AppDbContext _dbContext;
		

        public IActionResult Index(int id, int page)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            //var categories = await _dbContext.Categories.ToListAsync(); 

            return View(null);
        }


		[HttpGet]
		//public async Task<IActionResult> ListWithService([FromQuery] string? searchKey = null)
		//{
  //          var sonuc = await _categoryService.GetCategories(searchKey);

		//	return View(sonuc);
		//}
	}
}
