using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Extensions.Options;
using MudahMed.Common.ConfigSetting;
using MudahMed.Common.Constants;
using MudahMed.Common.Encrypt;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel.User;
using MudahMed.Services.Abstract;
using System.Security.Principal;
using X.PagedList;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/auth")]
    [Route("admin")]
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly DataDbContext _context;
        private readonly IAppUserService _appUserService;
        private readonly int _maxResultLimit;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, DataDbContext context, IAppUserService appUserService, IOptions<AppSettings> appSettings)
        {
            this.signInManager = signInManager;
            this._userManager = userManager;
            this._context = context;
            this._appUserService = appUserService;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
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
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    
                    if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }

                    //get role by user
                    var roles = await _userManager.GetRolesAsync(user);
                    // check role
                    if (!roles.Contains("Admin"))
                    {
                        await signInManager.SignOutAsync();
                        ModelState.AddModelError(string.Empty, "This page is only for admin account.");
                    }
                    else if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
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

        [Route("list-system-user")]
        public async Task<IActionResult> ListSystemUser(int? page)
        {
            //var users = _context.AppUsers.OrderByDescending(u => u.Id).Where(u => u.Status != -1 && u.Status != 2).ToList();
            //var users = await _appUserService.GetAllUsers();
            var users = await _appUserService.GetUsersByRoleAsync(Role.Role_Administrator);

            users = users.Where(c => c.Status != 0).ToList();

            //var vms = _mapper.Map<IList<ListEmployersViewWModel>>(users);

            return View(users);
        }

        [Route("list-employer-user")]
        public async Task<IActionResult> ListEmployerUser(int? page)
        {
            //var users = _context.AppUsers.OrderByDescending(u => u.Id).Where(u => u.Status != -1 && u.Status != 2).ToList();
            //var users = await _appUserService.GetAllUsers();
            var users = await _appUserService.GetUsersByRoleAsync(Role.Role_Corporate);


            users = users.Where(c => c.Status != 0).ToList();
            //var vms = _mapper.Map<IList<ListEmployersViewWModel>>(users);

            return View(users);
        }

        [Route("list-clinic-user")]
        public async Task<IActionResult> ListClinicUser(int? page)
        {
            int pageSize = 5;
            //var users = _context.AppUsers.OrderByDescending(u => u.Id).Where(u => u.Status != -1 && u.Status != 2).ToList();
            //var users = await _appUserService.GetAllUsers();
            var users = await _appUserService.GetUsersByRoleAsync(Role.Role_Clinic);


            users = users.Where(c => c.Status != 0).ToList();
            //var vms = _mapper.Map<IList<ListEmployersViewWModel>>(users);

            //return View(users.ToPagedList(page ?? 1, _maxResultLimit));
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        //[AllowAnonymous]
        [Route("register")]
        public IActionResult Register(String userRole)
        {
            RegisterViewModel model = new RegisterViewModel();
            model.UserRole = userRole;
            ViewData["CorpId"] = new SelectList(_context.Corps.Where(c => c.IsActive == true).OrderBy(p => p.CorpID), "CorpID", "Corp_name");
            ViewData["ClinicId"] = new SelectList(_context.Clinics.Where(c => c.IsActive == true).OrderBy(p => p.ClinicID), "ClinicID", "Clinic_name");
            return View(model);
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
                return View("Register", model);
            }
            if (ModelState.IsValid)
            {
                var account = await _userManager.GetUserAsync(User); ; 

                model.UserRole = HashingAES256d.DecryptStringFromBytes_Aes(model.UserRole);
                var user = new AppUser
                {
                    UserName = model.Email,
                    FullName = model.FullName,
                    Email = model.Email,
                    Status = General.Status_Active,
                    CreatedDate = DateTime.Now,
                    CreatedBy = account.Id
                };

                if (model.UserRole == Role.Role_Administrator) 
                {
                    user.RefTable = AppUserRefference.tblCorp;
                    user.RefId = AppUserRefference.defaultCorpID;
                }
                else if (model.UserRole == Role.Role_Corporate || model.UserRole == Role.Role_Employee)
                {
                    user.RefTable = AppUserRefference.tblCorp;
                    user.RefId = model.RefId;
                }
                else if (model.UserRole == Role.Role_Clinic)
                {
                    user.RefTable = AppUserRefference.tblClinic;
                    user.RefId = model.RefId;
                }

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.UserRole);

                    if (model.UserRole == Role.Role_Administrator)
                    {
                        return RedirectToAction("ListSystemUser");
                    }
                    else if (model.UserRole == Role.Role_Corporate)
                    {
                        return RedirectToAction("ListEmployerUser");
                    }
                    else if (model.UserRole == Role.Role_Clinic)
                    {
                        return RedirectToAction("ListClinicUser");
                    }

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewData["CorpId"] = new SelectList(_context.Corps.Where(c => c.IsActive == true).OrderBy(p => p.CorpID), "CorpID", "Corp_name");
            ViewData["ClinicId"] = new SelectList(_context.Clinics.Where(c => c.IsActive == true).OrderBy(p => p.ClinicID), "ClinicID", "Clinic_name");

            return View(model);
        }

        [Route("edit-user/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditUserViewModel
            {
                Email = user.Email,
                FullName = user.FullName,
                Phone = user.PhoneNumber,
                RefId = user.RefId ?? 1,
                TwoFactorEnabled = user.TwoFactorEnabled,
            };

            if (user.RefTable == AppUserRefference.tblCorp && user.RefId == AppUserRefference.defaultCorpID)
            {
                model.UserRole = HashingAES256d.EncryptStringToBytes_Aes(Role.Role_Administrator);
            }
            else if (user.RefTable == AppUserRefference.tblCorp && user.RefId != AppUserRefference.defaultCorpID)
            {
                model.UserRole = HashingAES256d.EncryptStringToBytes_Aes(Role.Role_Corporate);
            }
            else if (user.RefTable == AppUserRefference.tblClinic)
            {
                model.UserRole = HashingAES256d.EncryptStringToBytes_Aes(Role.Role_Clinic);
            }


            // Populate dropdowns or other necessary data
            ViewData["CorpId"] = new SelectList(_context.Corps.Where(c => c.IsActive == true).OrderBy(p => p.CorpID), "CorpID", "Corp_name");
            ViewData["ClinicId"] = new SelectList(_context.Clinics.Where(c => c.IsActive == true).OrderBy(p => p.ClinicID), "ClinicID", "Clinic_name");

            return View(model);
        }

        [Route("edit-user/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditUser(string id, EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                    return View("NotFound");
                }

                var account = await _userManager.GetUserAsync(User); ;
                user.Email = model.Email;
                user.FullName = model.FullName;
                user.PhoneNumber = model.Phone;
                user.RefId = model.RefId; // Assuming RefId is a property in your user model
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = account.Id;
                user.TwoFactorEnabled = model.TwoFactorEnabled;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    if (user.RefTable == AppUserRefference.tblCorp && user.RefId == AppUserRefference.defaultCorpID)
                    {
                        return RedirectToAction("ListSystemUser");
                    }
                    else if (user.RefTable == AppUserRefference.tblCorp && user.RefId != AppUserRefference.defaultCorpID)
                    {
                        return RedirectToAction("ListEmployerUser");
                    }
                    else if (user.RefTable == AppUserRefference.tblClinic)
                    {
                        return RedirectToAction("ListClinicUser");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            // Populate dropdowns or other necessary data
            ViewData["CorpId"] = new SelectList(_context.Corps.Where(c => c.IsActive == true).OrderBy(p => p.CorpID), "CorpID", "Corp_name");
            ViewData["ClinicId"] = new SelectList(_context.Clinics.Where(c => c.IsActive == true).OrderBy(p => p.ClinicID), "ClinicID", "Clinic_name");

            return View(model);
        }

        [Route("delete-user")]
        [HttpGet]
        public async Task<IActionResult> DeleteUser(string userID)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userID);
                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {userID} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    var account = await _userManager.GetUserAsync(User); ;
                    // Mark as inactive instead of deleting
                    // Assuming there is an IsActive property in the user model
                    user.Status = General.Status_InActive;
                    user.ModifiedDate = DateTime.Now;
                    user.ModifiedBy = account.Id;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (user.RefTable == AppUserRefference.tblCorp && user.RefId == AppUserRefference.defaultCorpID)
                        {
                            return RedirectToAction("ListSystemUser");
                        }
                        else if (user.RefTable == AppUserRefference.tblCorp && user.RefId != AppUserRefference.defaultCorpID)
                        {
                            return RedirectToAction("ListEmployerUser");
                        }
                        else if (user.RefTable == AppUserRefference.tblClinic)
                        {
                            return RedirectToAction("ListClinicUser");
                        }
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            catch (System.Exception)
            {
                return View("NotFound");
            }

            return View("NotFound");
        }


        private bool IsUsernameExists(string email)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);
            return existingUser != null;
        }
    }
}