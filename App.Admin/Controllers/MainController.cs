using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using App.Data.Entity;
using App.Admin.Models;

namespace App.Admin.Controllers
{
    //deneme
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
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