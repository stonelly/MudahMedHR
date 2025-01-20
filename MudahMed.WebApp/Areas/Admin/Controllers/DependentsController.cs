using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel.Dep;
using MudahMed.Services;
using MudahMed.Services.Abstract;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/authorization")]
    [Route("admin/dependent")]
    public class DependentsController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IQRCodeService _qrCodeService;
        private readonly IDependentService _dependentService;
        private readonly IEmployeeService _employeeService;

        public DependentsController(IDependentService dependentService, IEmployeeService employeeService, DataDbContext context, IQRCodeService qrCodeService)
        {
            _context = context;
            _qrCodeService = qrCodeService;
            _employeeService = employeeService;
            _dependentService = dependentService;
        }

        [Route("list-dependent")]
        [HttpGet]
        public async Task<IActionResult> Index(string Dep_name, string Dep_ic)
        {
            var dependents = await _dependentService.GetAllDependents();
            if (!string.IsNullOrEmpty(Dep_name))
            {
                dependents = dependents.Where(d => d.Dep_name.Contains(Dep_name));
            }
            if (!string.IsNullOrEmpty(Dep_ic))
            {
                dependents = dependents.Where(d => d.Dep_ic.Contains(Dep_ic));
            }
            return View(dependents);
        }


        [Route("create-dependent")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CorpID"] = new SelectList(_context.Corps, "CorpID", "Corp_name");
            return View();
        }

        [Route("create-dependent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DependentViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _dependentService.CreateDependentAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CorpID"] = new SelectList(_context.Corps, "CorpID", "Corp_name", model.Emp_id);
            return View(model);
        }

        [Route("edit-dependent/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _dependentService.GetDependentByIdAsync(id.Value);
            if (dependent == null)
            {
                return NotFound();
            }
            ViewData["CorpID"] = new SelectList(_context.Corps, "CorpID", "Corp_name", dependent.Emp_id);
            ViewData["QRCodeImage"] = GenerateDependentQRCode(dependent.Emp_id);
            return View(dependent);
        }

        [Route("edit-dependent/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(DependentViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _dependentService.UpdateDependentAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CorpID"] = new SelectList(_context.Corps, "CorpID", "Corp_name", model.Emp_id);
            ViewData["QRCodeImage"] = GenerateDependentQRCode(model.Emp_id);
            return View(model);
        }

        [Route("delete-Dep")]
        [HttpGet]
        public async Task<IActionResult> DeleteDep(int depID)
        {
            try
            {
                var model = await _dependentService.GetDependentByIdAsync(depID);
                if (model == null)
                {
                    ViewBag.ErrorMessage = $"Dependent with Id = {depID} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    // Mark as inactive instead of deleting
                    // Assuming there is an IsActive property in the CorpViewModel class
                    model.IsActive = false;
                    await _dependentService.UpdateDependentAsync(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (System.Exception)
            {
                return View("NotFound");
            }
        }
        [Route("delete-dependent/{id}")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependents
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Dep_id == id);
            if (dependent == null)
            {
                return NotFound();
            }

            return View(dependent);
        }

        // POST: Dependents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dependent = await _context.Dependents.FindAsync(id);
            _context.Dependents.Remove(dependent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DependentExists(int id)
        {
            return _context.Dependents.Any(e => e.Dep_id == id);
        }

        [Route("GetEmpyByCorp")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeesByCorp(int corpId)
        {

            var employees = _employeeService.GetAllEmployees().Result.Where(c => c.IsActive == true && c.CorpID == corpId.ToString())
                .Select(e => new { value = e.Emp_id, text = e.Emp_name }).ToList();
            //var employees = await _context.Employees
            //    .Where(e => e.CorpID == corpId.ToString())
            //    .Select(e => new { value = e.Emp_id, text = e.Emp_name })
            //    .ToListAsync();

            return Json(employees);
        }



        [HttpGet]
        public IActionResult BulkUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BulkUpload(DependentBulkUploadViewModel model)
        {
            if (model.File == null || model.File.Length == 0)
            {
                ModelState.AddModelError("File", "Please upload a valid Excel file.");
                return View(model);
            }

            var dependents = new List<Dependent>();

            using (var stream = new MemoryStream())
            {
                await model.File.CopyToAsync(stream);
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rowCount = worksheet.Rows().Count();

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var corpId = int.Parse(worksheet.Cell(row, 1).GetString());
                        var empIc = worksheet.Cell(row, 2).GetString();

                        var empId = _context.Employees
                            .Where(e => e.CorpID == corpId.ToString() && e.Emp_ic == empIc)
                            .Select(e => e.Emp_id)
                            .FirstOrDefault();

                        if (empId == 0)
                        {
                            ModelState.AddModelError("File", $"Employee with CorpID {corpId} and IC {empIc} not found.");
                            continue;
                        }

                        var dependent = new Dependent
                        {
                            Emp_id = empId,
                            Dep_name = worksheet.Cell(row, 3).GetString(),
                            Dep_ic = worksheet.Cell(row, 4).GetString(),
                            BenefitID = worksheet.Cell(row, 5).GetString(),
                            Relationship = worksheet.Cell(row, 6).GetString(),
                            Dep_gender = worksheet.Cell(row, 7).GetString(),
                            Dep_dob = DateTime.Parse(worksheet.Cell(row, 8).GetString()),
                            Dep_race = worksheet.Cell(row, 9).GetString(),
                            Dep_nationality = worksheet.Cell(row, 10).GetString(),
                            Join_dt = DateTime.Parse(worksheet.Cell(row, 11).GetString()),
                            Ent_dt = DateTime.Parse(worksheet.Cell(row, 12).GetString()),
                            ClientNumber = worksheet.Cell(row, 13).GetString(),
                            Remarks = worksheet.Cell(row, 14).GetString(),
                            IsActive = bool.Parse(worksheet.Cell(row, 15).GetString()),
                            CreatedDate = DateTime.Parse(worksheet.Cell(row, 16).GetString()),
                            LastModifiedBy = worksheet.Cell(row, 17).GetString(),
                            LastModifiedDate = DateTime.Parse(worksheet.Cell(row, 18).GetString()),
                            DepResignDT = DateTime.Parse(worksheet.Cell(row, 19).GetString())
                        };

                        dependents.Add(dependent);
                    }
                }
            }

            model.Dependents = dependents;

            if (ModelState.IsValid)
            {
                _context.Dependents.AddRange(dependents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        // GET: Dependents/GenerateQRCode/5
        private string GenerateDependentQRCode(int? id)
        {
            if (id == null)
            {
                return string.Empty;
            }

            var dependent = _context.Dependents.Find(id);
            if (dependent == null)
            {
                return string.Empty;
            }

            string qrData = $"D|{dependent.Dep_id}|{dependent.Emp_id}";
            Bitmap qrCodeImage = _qrCodeService.GenerateQRCode(qrData);

            using (var memoryStream = new MemoryStream())
            {
                qrCodeImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                string imgSrc = $"data:image/png;base64,{base64String}";
                return imgSrc;
            }

            return string.Empty;
        }
    }
}
