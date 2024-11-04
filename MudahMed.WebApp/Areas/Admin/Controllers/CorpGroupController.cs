using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MudahMed.Common.ConfigSetting;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel;
using MudahMed.Data.ViewModel.CorpGroup;
using MudahMed.Services.Abstract;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/authorization")]
    [Route("admin/corpgroup")]
    public class CorpGroupController : Controller
    {
        private readonly DataDbContext _context;
        private readonly ICorpGroupService _corpGroupService;
        private readonly int _maxResultLimit;

        public CorpGroupController(ICorpGroupService corpGroupService, IOptions<AppSettings> appSettings, DataDbContext context)
        {
            _context = context;
            _corpGroupService = corpGroupService;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
        }

        [Route("list-corpgroups")]
        [HttpGet]
        public async Task<IActionResult> ListCorpGroups(string city)
        {
            int limit = _maxResultLimit;
            var corpGroups = await _corpGroupService.GetAllCorpGroups();

            if (string.IsNullOrEmpty(city))
                limit = int.MaxValue;

            var corpGroupList = corpGroups.Take(limit).ToList();

            if (!string.IsNullOrEmpty(city))
            {
                corpGroupList = corpGroupList.Where(cg => cg.city.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(corpGroupList);
        }

        [Route("create-corpgroup")]
        [HttpGet]
        public IActionResult CreateCorpGroup()
        {
            ViewData["BankId"] = new SelectList(_context.Banks.OrderBy(p => p.Bank_id), "Bank_id", "Bank_name");
            return View();
        }

        [Route("create-corpgroup")]
        [HttpPost]
        public async Task<IActionResult> CreateCorpGroup(CorpGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _corpGroupService.CreateCorpGroupAsync(model);
                return RedirectToAction("ListCorpGroups");
            }

            return View(model);
        }

        [Route("edit-corpgroup/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditCorpGroup(int id)
        {
            ViewData["BankId"] = new SelectList(_context.Banks.OrderBy(p => p.Bank_id), "Bank_id", "Bank_name");
            var model = await _corpGroupService.GetCorpGroupByIdAsync(id);
            if (model == null)
            {
                ViewBag.ErrorMessage = $"CorpGroup with Id = {id} cannot be found";
                return View("NotFound");
            }
            return View(model);
        }

        [Route("edit-corpgroup/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditCorpGroup(CorpGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _corpGroupService.UpdateCorpGroupAsync(model);
                return RedirectToAction("ListCorpGroups");
            }
            return View(model);
        }

        [Route("delete-corpgroup")]
        [HttpGet]
        public async Task<IActionResult> DeleteCorpGroup(int corpGroupID)
        {
            try
            {
                var model = await _corpGroupService.GetCorpGroupByIdAsync(corpGroupID);
                if (model == null)
                {
                    ViewBag.ErrorMessage = $"CorpGroup with Id = {corpGroupID} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    // Mark as inactive instead of deleting
                    // Assuming there is an IsActive property in the CorpGroupViewModel class
                    model.IsActive = false;
                    await _corpGroupService.UpdateCorpGroupAsync(model);
                    return RedirectToAction("ListCorpGroups");
                }
            }
            catch (System.Exception)
            {
                return View("NotFound");
            }
        }
    }

}
