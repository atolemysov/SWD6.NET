using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Models;
using courseProject.Services;
using courseProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace courseProject.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly UsersService _usersService;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager, UsersService usersService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _usersService = usersService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Patient")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "/");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Full_Name = model.Full_Name,
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "/");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }


        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "/");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
    }
}
