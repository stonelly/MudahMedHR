using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MudahMed.Common.ConfigSetting;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel.IndustryField;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/authorization")]
    [Route("admin/industryField")]
    public class IndustryFieldController : Controller
    {
        private readonly DataDbContext _context;
        private readonly int _maxResultLimit;

        public IndustryFieldController(DataDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
        }

        [Route("list-industryFields")]
        [HttpGet]
        public async Task<IActionResult> ListIndustryFields(string searchName)
        {
            var industryFields = _context.IndustryFields.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                industryFields = industryFields.Where(r => r.IndustryFieldName.Contains(searchName));
            }

            List<IndustryFieldViewModel> industryFieldViewModels = new List<IndustryFieldViewModel>();

            foreach (var industryField in industryFields)
            {
                industryFieldViewModels.Add(new IndustryFieldViewModel
                {
                    ItemID = industryField.ItemID,
                    IndustryFieldName = industryField.IndustryFieldName
                });
            }
            // If no search criteria provided, take only the limit
            if (string.IsNullOrEmpty(searchName))
            {
                industryFieldViewModels = industryFieldViewModels.Take(_maxResultLimit).ToList();
            }

            return View(industryFieldViewModels);
        }

        // GET: IndustryFieldController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("create-industryField")]
        [HttpGet]
        public IActionResult CreateIndustryField()
        {
            return View();
        }

        // POST: IndustryFieldController/Create
        [ValidateAntiForgeryToken]
        [Route("create-industryField")]
        [HttpPost]
        public async Task<IActionResult> CreateIndustryField(IndustryFieldViewModel model)
        {
            if (ModelState.IsValid)
            {
                IndustryField industryField = new IndustryField
                {
                    IndustryFieldName = model.IndustryFieldName
                };


                _context.IndustryFields.Add(industryField);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListIndustryFields");

            }

            return View(model);
        }

        [Route("edit-industryField/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditIndustryField(int id)
        {

            var industryField = _context.IndustryFields.Where(u => u.ItemID == id).First();


            var model = new IndustryFieldViewModel
            {
                ItemID = industryField.ItemID,
                IndustryFieldName = industryField.IndustryFieldName
            };


            return View(model);
        }

        [Route("edit-industryField/{ItemID}")]
        [HttpPost]
        public async Task<IActionResult> EditIndustryField(IndustryFieldViewModel model)
        {
            if (ModelState.IsValid)
            {
                IndustryField industryField = _context.IndustryFields.Where(u => u.ItemID == model.ItemID).First();
                industryField.IndustryFieldName = model.IndustryFieldName;
                _context.IndustryFields.Update(industryField);
                await _context.SaveChangesAsync();

                return RedirectToAction("ListIndustryFields");
            }

            return View(model);
        }

        //[Route("delete-industryField/{IndustryFieldID}")]
        [Route("delete-industryField")]
        [HttpGet]
        public async Task<IActionResult> DeleteIndustryField(int IndustryFieldID)
        {
            try
            {
                IndustryField industryFieldHere = _context.IndustryFields.Where(u => u.ItemID == IndustryFieldID).First();

                if (industryFieldHere == null)
                {
                    ViewBag.ErrorMessage = $"Industry Field with Id = {IndustryFieldID} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    _context.IndustryFields.Remove(industryFieldHere);
                    _context.SaveChanges();
                    return RedirectToAction("ListIndustryFields");
                }

            }
            catch (System.Exception)
            {
                return View("NotFound");
            }
        }
    }
}
