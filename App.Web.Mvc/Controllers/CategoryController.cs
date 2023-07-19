using App.Data;
using App.Web.Mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
		//private readonly AppDbContext _dbContext;
		private readonly ICategoryService _categoryService;

		public CategoryController(
            //AppDbContext dbContext,
            ICategoryService categoryService)
        {
			//_dbContext = dbContext;
			_categoryService = categoryService;
		}

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
		public async Task<IActionResult> ListWithService([FromQuery] string? searchKey = null)
		{
            var sonuc = await _categoryService.GetCategories(searchKey);

			return View(sonuc);
		}
	}
}
