using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using Microsoft.AspNetCore.Identity;
using MudahMed.Data.ViewModel;
using X.PagedList;
using MudahMed.Common.Constants;
using MudahMed.Data.ViewModel.User;
using Microsoft.AspNetCore.Mvc.Rendering;
using MudahMed.Data.ViewModel.Emp;
using ClosedXML.Excel;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/apply-employer")]
    public class EmployerController : Controller
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public EmployerController(DataDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = _context.Employees.Include(e => e.Bank).Include(e => e.Dependents);
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Bank)
                .Include(e => e.Dependents)
                .FirstOrDefaultAsync(m => m.Emp_id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["BankID"] = new SelectList(_context.Banks, "BankID", "BankName");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Emp_id,Emp_ic,Emp_name,CorpID,Suboffice_fk,Dept_fk,BenefitID,Emp_gender,Emp_dob,Emp_race,Emp_nationality,Addr1,Addr2,Addr3,Postcode,City,State,Country,Email,Cont_no,Designation,Remarks,Join_dt,Ent_dt,BankID,BankAccNo,Resign_dt,ClientNumber,CostCentre,IsActive,CreatedDate,LastModifiedBy,LastModifiedDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankID"] = new SelectList(_context.Banks, "BankID", "BankName", employee.BankID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["BankID"] = new SelectList(_context.Banks, "BankID", "BankName", employee.BankID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Emp_id,Emp_ic,Emp_name,CorpID,Suboffice_fk,Dept_fk,BenefitID,Emp_gender,Emp_dob,Emp_race,Emp_nationality,Addr1,Addr2,Addr3,Postcode,City,State,Country,Email,Cont_no,Designation,Remarks,Join_dt,Ent_dt,BankID,BankAccNo,Resign_dt,ClientNumber,CostCentre,IsActive,CreatedDate,LastModifiedBy,LastModifiedDate")] Employee employee)
        {
            if (id != employee.Emp_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Emp_id))
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
            ViewData["BankID"] = new SelectList(_context.Banks, "BankID", "BankName", employee.BankID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Bank)
                .Include(e => e.Dependents)
                .FirstOrDefaultAsync(m => m.Emp_id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Emp_id == id);
        }


        [HttpGet]
        public IActionResult BulkUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BulkUpload(EmployeeBulkUploadViewModel model)
        {
            if (model.File == null || model.File.Length == 0)
            {
                ModelState.AddModelError("File", "Please upload a valid Excel file.");
                return View(model);
            }

            var employees = new List<Employee>();

            using (var stream = new MemoryStream())
            {
                await model.File.CopyToAsync(stream);
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rowCount = worksheet.Rows().Count();

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var employee = new Employee
                        {
                            Emp_ic = worksheet.Cell(row, 1).GetString(),
                            Emp_name = worksheet.Cell(row, 2).GetString(),
                            CorpID = worksheet.Cell(row, 3).GetString(),
                            Suboffice_fk = worksheet.Cell(row, 4).GetString(),
                            Dept_fk = worksheet.Cell(row, 5).GetString(),
                            BenefitID = worksheet.Cell(row, 6).GetString(),
                            Emp_gender = worksheet.Cell(row, 7).GetString(),
                            Emp_dob = DateTime.Parse(worksheet.Cell(row, 8).GetString()),
                            Emp_race = worksheet.Cell(row, 9).GetString(),
                            Emp_nationality = worksheet.Cell(row, 10).GetString(),
                            Addr1 = worksheet.Cell(row, 11).GetString(),
                            Addr2 = worksheet.Cell(row, 12).GetString(),
                            Addr3 = worksheet.Cell(row, 13).GetString(),
                            Postcode = worksheet.Cell(row, 14).GetString(),
                            City = worksheet.Cell(row, 15).GetString(),
                            State = worksheet.Cell(row, 16).GetString(),
                            Country = worksheet.Cell(row, 17).GetString(),
                            Email = worksheet.Cell(row, 18).GetString(),
                            Cont_no = worksheet.Cell(row, 19).GetString(),
                            Designation = worksheet.Cell(row, 20).GetString(),
                            Remarks = worksheet.Cell(row, 21).GetString(),
                            Join_dt = DateTime.Parse(worksheet.Cell(row, 22).GetString()),
                            Ent_dt = DateTime.Parse(worksheet.Cell(row, 23).GetString()),
                            BankID = worksheet.Cell(row, 24).GetString(),
                            BankAccNo = worksheet.Cell(row, 25).GetString(),
                            Resign_dt = DateTime.Parse(worksheet.Cell(row, 26).GetString()),
                            ClientNumber = worksheet.Cell(row, 27).GetString(),
                            CostCentre = worksheet.Cell(row, 28).GetString(),
                            IsActive = bool.Parse(worksheet.Cell(row, 29).GetString()),
                            CreatedDate = DateTime.Parse(worksheet.Cell(row, 30).GetString()),
                            LastModifiedBy = worksheet.Cell(row, 31).GetString(),
                            LastModifiedDate = DateTime.Parse(worksheet.Cell(row, 32).GetString())
                        };

                        employees.Add(employee);
                    }
                }
            }

            model.Employees = employees;

            if (ModelState.IsValid)
            {
                _context.Employees.AddRange(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}