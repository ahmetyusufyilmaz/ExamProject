using Business.Abstract;
using Business.ViewModels;
using ExamProject.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExamProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[Route("/[controller]s/Login")]
        //[HttpPost]

        //public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        //{
        //    var loggedValue = _userService.Get(u => u.Email == loginViewModel.Email && u.Password == loginViewModel.Password);
        //    if(loggedValue is not null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Email,loginViewModel.Email)
        //        };

        //        var userIdentity = new ClaimsIdentity(claims, "Login");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(principal);
        //        return Redirect("http://localhost:11567/admin/panel");
        //    }
        //    return View();
        //}

        [HttpGet]
        [Route("/[controller]s/Logout")]
        public async Task<IActionResult>Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("http://localhost:11567/posts");
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
