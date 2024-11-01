using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MudahMed.Common.ConfigSetting;
using MudahMed.Data.DataContext;
using MudahMed.Data.ViewModel.Clinic;
using MudahMed.Services.Abstract;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/authorization")]
    [Route("admin/drug")]
    public class DrugController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IDrugService _drugService;
        private readonly int _maxResultLimit;

        public DrugController(IDrugService drugService, IOptions<AppSettings> appSettings, DataDbContext context)
        {
            _context = context;
            _drugService = drugService;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
        }

        [Route("list-drugs")]
        [HttpGet]
        public async Task<IActionResult> ListDrugs(string drugCategory)
        {
            int limit = _maxResultLimit;
            var drugs = await _drugService.GetAllDrugs();

            if (string.IsNullOrEmpty(drugCategory))
                limit = int.MaxValue;

            var drugList = drugs.Take(limit).ToList();

            if (!string.IsNullOrEmpty(drugCategory))
            {
                drugList = drugList.Where(d => d.DrugCatFFS_CodeFK.Contains(drugCategory, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(drugList);
        }

        [Route("create-drug")]
        [HttpGet]
        public IActionResult CreateDrug()
        {
            return View();
        }

        [Route("create-drug")]
        [HttpPost]
        public async Task<IActionResult> CreateDrug(DrugViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _drugService.CreateDrugAsync(model);
                return RedirectToAction("ListDrugs");
            }

            return View(model);
        }

        [Route("edit-drug/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditDrug(string id)
        {
            var model = await _drugService.GetDrugByIdAsync(id);
            if (model == null)
            {
                ViewBag.ErrorMessage = $"Drug with Id = {id} cannot be found";
                return View("NotFound");
            }
            return View(model);
        }

        [Route("edit-drug/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditDrug(DrugViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _drugService.UpdateDrugAsync(model);
                return RedirectToAction("ListDrugs");
            }
            return View(model);
        }

        [Route("delete-drug/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteDrug(string id)
        {
            try
            {
                var model = await _drugService.GetDrugByIdAsync(id);
                if (model == null)
                {
                    ViewBag.ErrorMessage = $"Drug with Id = {id} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    model.IsActive = false; // Mark as inactive instead of deleting
                    await _drugService.UpdateDrugAsync(model);
                    return RedirectToAction("ListDrugs");
                }
            }
            catch (System.Exception)
            {
                return View("NotFound");
            }
        }
    }

}
