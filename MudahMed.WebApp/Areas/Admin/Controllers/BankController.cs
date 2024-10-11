using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel;
using MudahMed.Data.ViewModel.Bank;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/bank")]
    public class BankController : Controller
    {
        private readonly DataDbContext _context;
        private readonly int _maxResultLimit;

        public BankController(DataDbContext context, int maxResultLimit)
        {
            _context = context;
            _maxResultLimit = maxResultLimit;
        }
        // GET: BankController
        public ActionResult Index(string searchName)
        {
            var banks = _context.Banks.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                banks = banks.Where(r => r.Bank_name.Contains(searchName));
            }

            List<BankViewModel> bankViewModels = new List<BankViewModel>();

            foreach (var bank in banks)
            {
                bankViewModels.Add(new BankViewModel
                {
                    BankID = bank.Bank_id,
                    BankName = bank.Bank_name,
                    IsDisplay = bank.IsDisplay,
                });
            }
            // If no search criteria provided, take only the limit
            if (string.IsNullOrEmpty(searchName))
            {
                bankViewModels = bankViewModels.Take(_maxResultLimit).ToList();
            }

            return View(bankViewModels);
        }

        // GET: BankController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BankController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BankController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BankController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BankController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BankController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
