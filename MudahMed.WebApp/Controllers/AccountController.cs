using MudahMed.Common;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MudahMed.Common.Constants;
using MudahMed.Services;
using MudahMed.Data.ViewModel.User;

namespace MudahMed.WebApp.Controllers
{
    [Route("")]
    [Authorize(Roles = "Admin,Clinic,Corporate")]
    public class AccountController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly DataDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, DataDbContext context, IEmailSender emailSender)
        {
            this._userManager = userManager;
            this.signInManager = signInManager;
            this._context = context;
            _emailSender = emailSender;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        //[AllowAnonymous]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        //[AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (IsUsernameExists(model.Email))
            {
                ModelState.AddModelError("Email", "This account has already existed.");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    FullName = model.FullName,
                    Email = model.Email,
                    Status = null
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Role.Role_Clinic);
                    return RedirectToAction(nameof(Login));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login()
        {
            if (TempData.ContainsKey("PasswordChanged") && (bool)TempData["PasswordChanged"])
            {
                ViewBag.PasswordChanged = true;
            }
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
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid account or password. Please try again !");
                    return View(model);
                }
            }
            return View(model);
        }

        [Route("logout")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [Route("change-password")]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Route("change-password")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "The password and confirmation password do not match.");
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
            await signInManager.RefreshSignInAsync(user);
            TempData["PasswordChanged"] = true;
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        private bool IsUsernameExists(string email)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);
            return existingUser != null;
        }


        [Route("forgotpassword")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction("ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                    $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
                return RedirectToAction("ForgotPasswordConfirmation");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("forgotpasswordconfirmation")]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("resetpassword")]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }

        [AllowAnonymous]
        [Route("resetpasswordconfirmation")]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}