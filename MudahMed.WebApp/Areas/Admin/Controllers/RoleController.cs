using MudahMed.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MudahMed.Common.ConfigSetting;
using Microsoft.Extensions.Options;
using MudahMed.Common.Encrypt;
using MudahMed.Data.ViewModel.User;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/authorization")]
    [Route("admin/auth")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly int _maxResultLimit;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IOptions<AppSettings> appSettings)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
        }

        [Route("list-roles")]
        [HttpGet]
        public async Task<IActionResult> ListRoles(string roleName, string roleDescription)
        {
            var roles = roleManager.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(roleName))
            {
                roles = roles.Where(r => r.Name.Contains(roleName));
            }

            if (!string.IsNullOrEmpty(roleDescription))
            {
                roles = roles.Where(r => r.Description.Contains(roleDescription));
            }

            List<RoleViewModel> roleViewModels = new List<RoleViewModel>();

            foreach (var role in roles)
            {
                // Check if there are any users assigned to this role
                var userCount = await userManager.GetUsersInRoleAsync(role.Name);

                roleViewModels.Add(new RoleViewModel
                {
                    Id = role.Id.ToString(),
                    Name = role.Name,
                    Description = role.Description,
                    EncryptedKey = HashingAES256d.EncryptStringToBytes_Aes(role.Name),
                    IsAssigned = userCount.Any() // True if there are users assigned
                });
            }




            // If no search criteria provided, take only the limit
            if (string.IsNullOrEmpty(roleName) && string.IsNullOrEmpty(roleDescription))
            {
                roleViewModels = roleViewModels.Take(_maxResultLimit).ToList();
            }

            return View(roleViewModels);
        }

        [Route("create-role")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [Route("create-role")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole
                {
                    Name = model.RoleName,
                    Description = model.RoleDescription
                };

                IdentityResult result = await roleManager.CreateAsync(appRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        
        [Route("edit-role/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditRole(Guid id)
        {
            // Find the role by Role ID
            var role = await roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                RoleDescription = role.Description
            };

            foreach (var user in userManager.Users)
            {

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [Route("edit-role/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id.ToString());
            if (role == null)
            {
                ViewBag.ErrorMessage =
                    $"Role with Id: {model.Id} could not be found";
                return View("NotFound");
            }

            //role.Name = model.RoleName;
            role.Description = model.RoleDescription;
            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [Route("edit-user-role/{roleId}")]
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(Guid roleId)
        {
            ViewBag.roleId = roleId;
            var role = await roleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [Route("edit-user-role/{roleId}")]
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, Guid roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId.ToString());

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        [Route("delete-role")]
        [HttpGet]
        public async Task<IActionResult> DeleteRole(Guid roleID)
        {
            var role = await roleManager.FindByIdAsync(roleID.ToString());

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleID} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListRoles");
            }
        }
    }
}