﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MudahMed.Common.Constants;
using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel.User;

namespace MudahMed.WebApp.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("employer/auth")]
    [Route("employer")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                            model.Email,
                            model.Password,
                            model.RememberMe,
                            false);
                if (result.Succeeded)
                {
                    //get email from login site and check 
                    var user = await userManager.FindByEmailAsync(model.Email);
                    if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                    
                    //get role by user
                    var roles = await userManager.GetRolesAsync(user);
                    if (!roles.Contains(Role.Role_Corporate) && !roles.Contains(Role.Role_Clinic))
                    {
                        await signInManager.SignOutAsync();
                        ModelState.AddModelError(string.Empty, "This page is only for Hr/ corporate accounts.");
                    }
                    else if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {

                        if(roles.Contains(Role.Role_Clinic))
                            return RedirectToAction("index", "home", new { area = "Clinic",id = user.Id });
                        else
                            return RedirectToAction("index", "home", new { id = user.Id });
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid account or password. Please try again !");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}