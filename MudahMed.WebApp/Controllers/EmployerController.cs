using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using MudahMed.Data.ViewModel;
using MudahMed.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using MudahMed.Common.Constants;

namespace MudahMed.WebApp.Controllers
{
    [Authorize(Roles = "Admin,Corporate")]
    [Route("register-employer")]
    public class EmployerController : Controller
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> userManager;

        public EmployerController(UserManager<AppUser> userManager, DataDbContext context)
        {
            this.userManager = userManager;
            this._context = context;
        }

        [Authorize(Roles = "Admin")]
        [Route("register/{id}")]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [Route("register/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Guid id, UpdateEmployerViewModel model)
        {
            string POST_IMAGE_PATH = "images/employers/";

            AppUser employer = _context.AppUsers.Where(u => u.Id == id).First();
            employer.FullName = model.FullName;
            employer.Email = employer.UserName = model.Email;
            employer.NormalizedEmail = employer.NormalizedUserName = (employer.Email ?? model.Email).ToUpper();
            employer.CreatedDate = DateTime.Now;
            employer.Status = 1; // waiting to confirm
            _context.Update(employer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        [Route("register")]
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult RegisterToEmployer()
        {
         
            return View();
        }

        [Authorize(Roles = "Admin")]
        [Route("register")]
        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> RegisterToEmployer(RegisterEmployerViewModel model)
        {
            string POST_IMAGE_PATH = "images/employers/";
            if (IsUsernameExists(model.Email))
            {
                ModelState.AddModelError("Email", "This account has already existed.");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                var image = UploadImage.UploadImageFile(model.UrlAvatar, POST_IMAGE_PATH);

                var employer = new AppUser
                {
                    UserName = model.Email,
                    FullName = model.FullName,
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    NormalizedUserName = model.Email.ToUpper(),
                    CreatedDate = DateTime.Now,
                    Status = 1 // waiting to confirm
                };
                var result = await userManager.CreateAsync(employer, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(employer, Role.Role_Corporate);
                    return Redirect("/login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [Route("update/{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            var employer = await _context.AppUsers.Where(e => e.Id == id).FirstAsync();
            return View(employer);
        }

        [Route("update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, UpdateEmployerViewModel model)
        {
            string POST_IMAGE_PATH = "images/employers/";

            AppUser employer = _context.AppUsers.Where(u => u.Id == id).First();

            //fix bug for null value
            if (model.FullName != null)
            {
                employer.FullName = model.FullName;
            }

           
            employer.Email = employer.UserName = model.Email;
            employer.NormalizedEmail = employer.NormalizedUserName = (employer.Email ?? model.Email).ToUpper();

            _context.Update(employer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool IsUsernameExists(string email)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);
            return existingUser != null;
        }
    }
}