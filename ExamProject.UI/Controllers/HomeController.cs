using Business.Abstract;
using Business.ViewModels;
using ExamProject.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public HomeController(IUserService userService, IConfiguration configuration = null)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(_userService.Login(model))
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Email));
                if(model.Email == _configuration["AdminEmail Adresi gelecek"])
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Member"));
                }
              
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                return Redirect("Privacy");
            }
            TempData["Error"] = "Error. Username or Password is invalid";
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        //[HttpPost]

        //public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var loggedValue = _userService.Login(loginViewModel);
        //        if (!loggedValue)
        //        {
        //            var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Email,loginViewModel.Email),
        //            new Claim(ClaimTypes.Name,"Admin"),
        //            new Claim(ClaimTypes.Role,"Admin"),

        //        };

        //            var userIdentity = new ClaimsIdentity(claims, "Login");
        //            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //            await HttpContext.SignInAsync(principal);
        //            return Redirect("Home");
        //        }
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        public IActionResult Register()
        {
            return View();
        }




        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var loggedValue = _userService.Register(registerViewModel);
            if (loggedValue)
            {
                return Redirect("Login");
            }
            return View("Register");
        }

        //[HttpGet]
        //public async Task<IActionResult>Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return Redirect("http://localhost:11567/posts");
        //}

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
