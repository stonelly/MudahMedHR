using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MudahMed.Common.ConfigSetting;
using MudahMed.Common.Constants;
using MudahMed.Data.DataContext;
using MudahMed.Data.ViewModel.General;
using MudahMed.Services.Abstract;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/authorization")]
    [Route("admin/codemaster")]
    public class CodeMasterController : Controller
    {
        private readonly DataDbContext _context;
        private readonly ICodeMasterService _codeMasterService;
        private readonly int _maxResultLimit;

        public CodeMasterController(ICodeMasterService codeMasterService, IOptions<AppSettings> appSettings, DataDbContext context)
        {
            _context = context;
            _codeMasterService = codeMasterService;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
        }

        [Route("list-codemasters")]
        [HttpGet]
        public async Task<IActionResult> ListCodeMasters(string codeType)
        {
            int limit = _maxResultLimit;
            var codeMasters = await _codeMasterService.GetAllCodeMasters();

            if (string.IsNullOrEmpty(codeType))
                limit = int.MaxValue;

            var codeMasterList = codeMasters.Take(limit).ToList();

            if (!string.IsNullOrEmpty(codeType))
            {
                codeMasterList = codeMasterList.Where(mc => mc.CodeType.Contains(codeType, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(codeMasterList);
        }

        [Route("create-codemaster")]
        [HttpGet]
        public IActionResult CreateCodeMaster()
        {
            var codeMasters = _codeMasterService.GetAllCodeMastersByCodeType(General.CodeMasterType).Result.ToList();
            ViewData["CodeMasterId"] = new SelectList(codeMasters, "CodeValue", "CodeDescription");
            return View();
        }

        [Route("create-codemaster")]
        [HttpPost]
        public async Task<IActionResult> CreateCodeMaster(CodeMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _codeMasterService.CreateCodeMasterAsync(model);
                return RedirectToAction("ListCodeMasters");
            }

            return View(model);
        }

        [Route("edit-codemaster/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditCodeMaster(int id)
        {
            var model = await _codeMasterService.GetCodeMasterByIdAsync(id);
            if (model == null)
            {
                ViewBag.ErrorMessage = $"Master Code with Id = {id} cannot be found";
                return View("NotFound");
            }
            return View(model);
        }

        [Route("edit-codemaster/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditCodeMaster(CodeMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _codeMasterService.UpdateCodeMasterAsync(model);
                return RedirectToAction("ListCodeMasters");
            }
            return View(model);
        }

        [Route("delete-codemaster")]
        [HttpGet]
        public async Task<IActionResult> DeleteCodeMaster(int codeMasterID)
        {
            try
            {
                var model = await _codeMasterService.GetCodeMasterByIdAsync(codeMasterID);
                if (model == null)
                {
                    ViewBag.ErrorMessage = $"Master Code with Id = {codeMasterID} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    model.IsActive = false; // Mark as inactive instead of deleting
                    await _codeMasterService.UpdateCodeMasterAsync(model);
                    return RedirectToAction("ListCodeMasters");
                }
            }
            catch (System.Exception)
            {
                return View("NotFound");
            }
        }
    }

}
