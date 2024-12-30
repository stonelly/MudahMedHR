using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel.Dep;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    public class DependentsController : Controller
    {
        private readonly DataDbContext _context;

        public DependentsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Dependents
        public async Task<IActionResult> Index()
        {
            var dependents = _context.Dependents.Include(d => d.Employee);
            return View(await dependents.ToListAsync());
        }

        // GET: Dependents/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Dependents/Create
        public IActionResult Create()
        {
            ViewData["CorpID"] = new SelectList(_context.Corps, "CorpID", "Corp_name");
            return View();
        }

        // POST: Dependents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dep_id,Emp_id,Dep_name,Dep_ic,BenefitID,Relationship,Dep_gender,Dep_dob,Dep_race,Dep_nationality,Join_dt,Ent_dt,ClientNumber,Remarks,IsActive,CreatedDate,LastModifiedBy,LastModifiedDate,DepResignDT")] Dependent dependent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CorpID"] = new SelectList(_context.Corps, "CorpID", "Corp_name", dependent.Emp_id);
            return View(dependent);
        }

        // GET: Dependents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependents.FindAsync(id);
            if (dependent == null)
            {
                return NotFound();
            }
            ViewData["CorpID"] = new SelectList(_context.Corps, "CorpID", "Corp_name", dependent.Emp_id);
            return View(dependent);
        }

        // POST: Dependents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dep_id,Emp_id,Dep_name,Dep_ic,BenefitID,Relationship,Dep_gender,Dep_dob,Dep_race,Dep_nationality,Join_dt,Ent_dt,ClientNumber,Remarks,IsActive,CreatedDate,LastModifiedBy,LastModifiedDate,DepResignDT")] Dependent dependent)
        {
            if (id != dependent.Dep_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependentExists(dependent.Dep_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CorpID"] = new SelectList(_context.Corps, "CorpID", "Corp_name", dependent.Emp_id);
            return View(dependent);
        }

        // GET: Dependents/Delete/5
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

        [HttpGet]
        public async Task<IActionResult> GetEmployeesByCorp(int corpId)
        {
            var employees = await _context.Employees
                .Where(e => e.CorpID == corpId.ToString())
                .Select(e => new { value = e.Emp_id, text = e.Emp_name })
                .ToListAsync();

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
    }
}
