using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MudahMed.Common.ConfigSetting;
using MudahMed.Common.Constants;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel.Corporate;
using MudahMed.Services;
using MudahMed.Services.Abstract;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/authorization")]
    [Route("admin/corp")]
    public class CorpController : Controller
    {
        private readonly DataDbContext _context;
        private readonly ICorpGroupService _corpGroupService;
        private readonly ICorpService _corpService;
        private readonly int _maxResultLimit;

        public CorpController(ICorpGroupService corpGroupService, ICorpService corpService, IOptions<AppSettings> appSettings, DataDbContext context)
        {
            _context = context;
            _corpGroupService = corpGroupService;
            _corpService = corpService;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
        }

        [Route("list-corps")]
        [HttpGet]
        public async Task<IActionResult> ListCorps(string corp_name, string city)
        {
            int limit = _maxResultLimit;
            var corps = await _corpService.GetAllCorps();

            if (string.IsNullOrEmpty(city) && string.IsNullOrEmpty(corp_name))
                limit = int.MaxValue;

            var corpList = corps.Take(limit).ToList();

            if (!string.IsNullOrEmpty(city))
            {
                corpList = corpList.Where(c => c.city.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(corp_name))
            {
                corpList = corpList.Where(c => c.Corp_name.Contains(corp_name, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(corpList);
        }

        [Route("create-corp")]
        [HttpGet]
        public IActionResult CreateCorp()
        {
            var corpGroups = _corpGroupService.GetAllCorpGroups().Result.Where(c => c.IsActive == true).ToList();
            ViewData["CorpGroupID"] = new SelectList(corpGroups, "CorpGroupID", "Name");
            ViewData["BankId"] = new SelectList(_context.Banks.OrderBy(p => p.Bank_id), "Bank_id", "Bank_name");
            ViewData["ItemID"] = new SelectList(_context.IndustryFields.OrderBy(p => p.ItemID), "ItemID", "IndustryFieldName");
            return View();
        }

        [Route("create-corp")]
        [HttpPost]
        public async Task<IActionResult> CreateCorp(CorpViewModel model)
        {
            ModelState.Remove("Bank");
            ModelState.Remove("CorpGroup");
            if (ModelState.IsValid)
            {
                await _corpService.CreateCorpAsync(model);
                return RedirectToAction("ListCorps");
            }

            return View(model);
        }

        [Route("edit-corp/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditCorp(int id)
        {
            var corpGroups = _corpGroupService.GetAllCorpGroups().Result.Where(c => c.IsActive == true).ToList();
            ViewData["CorpGroupID"] = new SelectList(corpGroups, "CorpGroupID", "Name");
            ViewData["BankId"] = new SelectList(_context.Banks.OrderBy(p => p.Bank_id), "Bank_id", "Bank_name");
            ViewData["ItemID"] = new SelectList(_context.IndustryFields.OrderBy(p => p.ItemID), "ItemID", "IndustryFieldName");
            var model = await _corpService.GetCorpByIdAsync(id);
            if (model == null)
            {
                ViewBag.ErrorMessage = $"Corp with Id = {id} cannot be found";
                return View("NotFound");
            }
            return View(model);
        }

        [Route("edit-corp/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditCorp(CorpViewModel model)
        {
            ModelState.Remove("Bank");
            ModelState.Remove("CorpGroup");
            if (ModelState.IsValid)
            {
                await _corpService.UpdateCorpAsync(model);
                return RedirectToAction("ListCorps");
            }
            return View(model);
        }

        [Route("delete-corp")]
        [HttpGet]
        public async Task<IActionResult> DeleteCorp(int corpID)
        {
            try
            {
                var model = await _corpService.GetCorpByIdAsync(corpID);
                if (model == null)
                {
                    ViewBag.ErrorMessage = $"Corp with Id = {corpID} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    // Mark as inactive instead of deleting
                    // Assuming there is an IsActive property in the CorpViewModel class
                    model.IsActive = false;
                    await _corpService.UpdateCorpAsync(model);
                    return RedirectToAction("ListCorps");
                }
            }
            catch (System.Exception)
            {
                return View("NotFound");
            }
        }
    }

}
