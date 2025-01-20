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
using MudahMed.Services;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using MudahMed.Services.Abstract;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/authorization")]
    [Route("admin/employee")]
    public class EmployerController : Controller
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IQRCodeService _qrCodeService;
        private readonly ICorpService _corpService;
        private readonly IEmployeeService _employeeService;

        public EmployerController(IEmployeeService employeeService, DataDbContext context, UserManager<AppUser> userManager, ICorpService corpService, IQRCodeService qrCodeService)
        {
            _context = context;
            _userManager = userManager;
            _qrCodeService = qrCodeService;
            _corpService = corpService;
            _employeeService = employeeService;
        }

        [Route("list-employee")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployees();
            return View(employees);
        }

      

        [Route("create-employee")]
        [HttpGet]
        public IActionResult Create()
        {
            var corpGroups = _corpService.GetAllCorps().Result.Where(c => c.IsActive == true).ToList();
            ViewData["CorpID"] = new SelectList(corpGroups, "CorpID", "Corp_name");
            ViewData["BankId"] = new SelectList(_context.Banks.OrderBy(p => p.Bank_id), "Bank_id", "Bank_name");
            return View();
        }

        [Route("create-employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.CreateEmployeeAsync(model);
                return RedirectToAction(nameof(Index));
            }
            var corpGroups = _corpService.GetAllCorps().Result.Where(c => c.IsActive == true).ToList();
            ViewData["CorpID"] = new SelectList(corpGroups, "CorpID", "Corp_name");
            ViewData["BankId"] = new SelectList(_context.Banks.OrderBy(p => p.Bank_id), "Bank_id", "Bank_name");
            return View(model);
        }


        [Route("edit-employee/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            ViewData["BankId"] = new SelectList(_context.Banks.OrderBy(p => p.Bank_id), "Bank_id", "Bank_name");
            ViewData["QRCodeImage"] = GenerateQRCode(employee.Emp_id);
            return View(employee);
        }

        [Route("edit-employee/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankId"] = new SelectList(_context.Banks.OrderBy(p => p.Bank_id), "Bank_id", "Bank_name");
            ViewData["QRCodeImage"] = GenerateQRCode(model.Emp_id);

            return View(model);
        }

        [Route("delete-emp")]
        [HttpGet]
        public async Task<IActionResult> DeleteEmp(int empID)
        {
            try
            {
                var model = await _employeeService.GetEmployeeByIdAsync(empID);
                if (model == null)
                {
                    ViewBag.ErrorMessage = $"Employee with Id = {empID} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    // Mark as inactive instead of deleting
                    // Assuming there is an IsActive property in the CorpViewModel class
                    model.IsActive = false;
                    await _employeeService.UpdateEmployeeAsync(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (System.Exception)
            {
                return View("NotFound");
            }
        }

        //[Route("delete-employee/{id}")]
        //[HttpGet]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee);
        //}

        //// POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _employeeService.DeleteEmployeeAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}

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
                            BankID = Int32.Parse(worksheet.Cell(row, 24).GetString()),
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


        public String GenerateQRCode(int? id)
        {
            if (id == null)
            {
                return string.Empty;
            }

            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return string.Empty;
            }

            string qrData = $"E|{employee.Emp_id}|{employee.CorpID}";
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