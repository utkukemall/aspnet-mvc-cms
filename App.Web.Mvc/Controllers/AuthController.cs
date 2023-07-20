using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace App.Web.Mvc.Controllers
{
	public class AuthController : Controller
	{
		public IActionResult Register()
		{
			return View();
		}

		public IActionResult Login(string redirectUrl)
		{
			// Butonla Yönetici tarafına yönlendirilebilir orada giriş yapar.
			return View();
		}

		[HttpPost]
        public IActionResult Login([FromForm] LoginViewModel model, [FromServices] IConfiguration configuration) // Yalnızca hasta girişi olacak
        {
			if (!ModelState.IsValid)
			{
				return ValidationProblem(ModelState);
			}

			// check db if user exists


			//if ok do login


			if (User.IsInRole("Admin"))
            {

                return Redirect(configuration.GetValue<string>("AdminUrl"));
            }

			// Su
            return View();
        }

        public IActionResult ForgotPassword()
		{
			return View();
		}
	}

	// move this to models
	public class LoginViewModel
	{
		[Required, EmailAddress]
		public string Mail { get; set; } = string.Empty;
        public string Password { get; set; }
    }
}
