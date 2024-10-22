using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var clinics = await _clinicService.GetAllClinicsAsync();

            // Filter clinics based on the search criteria
            if (!string.IsNullOrEmpty(clinicName))
            {
                clinics = clinics.Where(c => c.ClinicName.Contains(clinicName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(city))
            {
                clinics = clinics.Where(c => c.City.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // If no search criteria provided, take only the limit
            if (string.IsNullOrEmpty(clinicName) && string.IsNullOrEmpty(city))
            {
                clinics = clinics.Take(_maxResultLimit).ToList();
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

                return RedirectToAction("list-clinics"); // Redirect to the list of clinics
            }

            return View(model); // If the model state is invalid, return the view with the model
        }
    }
}
