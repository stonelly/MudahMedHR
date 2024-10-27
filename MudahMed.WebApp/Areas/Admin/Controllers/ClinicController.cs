using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MudahMed.Common.ConfigSetting;
using MudahMed.Data.DataContext;
using MudahMed.Data.ViewModel.Clinic;
using MudahMed.Services.Abstract;
using System.Data.Entity;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/authorization")]
    [Route("admin/clinic")]
    public class ClinicController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IClinicService _clinicService;
        private readonly int _maxResultLimit;

        public ClinicController(IClinicService clinicService, IOptions<AppSettings> appSettings, DataDbContext context)
        {
            _context = context;
            _clinicService = clinicService;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
        }

        [Route("list-clinics")]
        [HttpGet]
        public async Task<IActionResult> ListClinics(string clinicName, string city)
        {
            int limit = _maxResultLimit;
            if (string.IsNullOrEmpty(clinicName) && string.IsNullOrEmpty(city))
                limit = int.MaxValue;

            var clinics = _clinicService.GetAllClinicsAsync().Result.Take(limit).ToList();

            // Filter clinics based on the search criteria
            if (!string.IsNullOrEmpty(clinicName))
            {
                clinics = clinics.Where(c => c.ClinicName.Contains(clinicName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(city))
            {
                clinics = clinics.Where(c => c.City.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(clinics);
        }

        [Route("create-clinic")]
        [HttpGet]
        public IActionResult CreateClinic()
        {

            ViewData["BankId"] = new SelectList(_context.Banks.OrderBy(p => p.Bank_id), "Bank_id", "Bank_name");
            return View();
        }

        [Route("create-clinic")]
        [HttpPost]
        public async Task<IActionResult> CreateClinic(ClinicViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Call the service to create the clinic
                await _clinicService.CreateClinicAsync(model);

                return RedirectToAction("ListClinics"); // Redirect to the list of clinics
            }

            return View(model); // If the model state is invalid, return the view with the model
        }


        [Route("edit-clinic/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditClinic(int id)
        {

            ViewData["BankId"] = new SelectList(_context.Banks.OrderBy(p => p.Bank_id), "Bank_id", "Bank_name");
            var model = await _clinicService.GetClinicByIdAsync(id);

            return View(model);
        }

        [Route("edit-clinic/{ClinicID}")]
        [HttpPost]
        public async Task<IActionResult> EditClinic(ClinicViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _clinicService.UpdateClinicAsync(model);

                return RedirectToAction("ListClinics");
            }

            return View(model);
        }

        //[Route("delete-clinic/{ClinicID}")]
        [Route("delete-clinic")]
        [HttpGet]
        public async Task<IActionResult> DeleteClinic(int ClinicID)
        {
            try
            {
                var model = await _clinicService.GetClinicByIdAsync(ClinicID);


                if (model == null)
                {
                    ViewBag.ErrorMessage = $"Clinic with Id = {ClinicID} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    model.RemovedDate = DateTime.Now;
                    model.IsActive = false;
                    await _clinicService.UpdateClinicAsync(model);
                    return RedirectToAction("ListClinics");
                }

            }
            catch (System.Exception)
            {
                return View("NotFound");
            }
        }
    }
}
