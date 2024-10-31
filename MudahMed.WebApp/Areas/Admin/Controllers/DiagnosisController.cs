using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MudahMed.Common.ConfigSetting;
using MudahMed.Data.DataContext;
using MudahMed.Data.ViewModel.Clinic;
using MudahMed.Services;
using MudahMed.Services.Abstract;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/authorization")]
    [Route("admin/diagnosis")]
    public class DiagnosisController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IDiagnosisService _diagnosisService;
        private readonly int _maxResultLimit;

        public DiagnosisController(IDiagnosisService diagnosisService, IOptions<AppSettings> appSettings, DataDbContext context)
        {
            _context = context;
            _diagnosisService = diagnosisService;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
        }

        [Route("list-diagnosis")]
        [HttpGet]
        public async Task<IActionResult> ListDiagnosis(string diagnosisCategory)
        {
            int limit = _maxResultLimit;
            if (string.IsNullOrEmpty(diagnosisCategory))
                limit = int.MaxValue;
            var diagnoses = _diagnosisService.GetAllDiagnosis().Result.Take(limit).ToList(); 

            if (!string.IsNullOrEmpty(diagnosisCategory))
            {
                diagnoses = diagnoses.Where(d => d.Diag_cat.Contains(diagnosisCategory, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(diagnoses);
        }

        [Route("create-diagnosis")]
        [HttpGet]
        public IActionResult CreateDiagnosis()
        {
            return View();
        }

        [Route("create-diagnosis")]
        [HttpPost]
        public async Task<IActionResult> CreateDiagnosis(DiagnosisViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _diagnosisService.CreateDiagnosisAsync(model);
                return RedirectToAction("ListDiagnosis");
            }

            return View(model);
        }

        [Route("edit-diagnosis/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditDiagnosis(string id)
        {
            var model = await _diagnosisService.GetDiagnosisByIdAsync(id);
            if (model == null)
            {
                ViewBag.ErrorMessage = $"Diagnosis with Id = {id} cannot be found";
                return View("NotFound");
            }
            return View(model);
        }

        [Route("edit-diagnosis/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditDiagnosis(DiagnosisViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _diagnosisService.UpdateDiagnosisAsync(model);
                return RedirectToAction("ListDiagnosis");
            }
            return View(model);
        }

        [Route("delete-diagnosis/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteDiagnosis(string id)
        {
            try
            {
                var model = await _diagnosisService.GetDiagnosisByIdAsync(id);
                if (model == null)
                {
                    ViewBag.ErrorMessage = $"Diagnosis with Id = {id} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    model.IsActive = false;
                    await _diagnosisService.UpdateDiagnosisAsync(model);
                    return RedirectToAction("ListDiagnosis");
                }
            }
            catch (System.Exception)
            {
                return View("NotFound");
            }
        }
    }
}