using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsMessenger.Models;
using StudentsMessenger.ViewsModels;

namespace StudentsMessenger.Controllers
{
    public class HomeController : Controller
    {
        private readonly BaseContext _context;
        private readonly UserManager<Student> _userManager;
        private readonly SignInManager<Student> _signInManager;
        private readonly ILogger _logger;

        public HomeController(
            UserManager<Student> userManager,
            SignInManager<Student> signInManager,
            ILogger<HomeController> logger,
            BaseContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            Student user = await _userManager.GetUserAsync(User);
            if (user != null)
                return RedirectToAction("Index", "Base");
            return RedirectToAction("Login", "Home");


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginView model)
        {
            if (ModelState.IsValid)
            {
                
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction(nameof(HomeController.Index), "Base");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationView model)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[-_@*]).{6,30}$");
            if (!regex.IsMatch(model.Password))
            {
                ModelState.AddModelError("Password", "Password is not secure enough");
            }
            if (ModelState.IsValid)
            {
                var user = new Student
                {
                    UserName = model.UserName,
                    Email = model.UserName,
                    FName = model.FName,
                    LName = model.LName,
                    Cours = model.Cours,
                    FNum = model.FNum,
                    FormOfTraning = model.FormOfTraning,
                    MName = model.MName,
                    Specialty = model.Specialty,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");

                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult Upload()
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
