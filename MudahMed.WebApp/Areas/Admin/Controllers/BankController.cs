using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MudahMed.Common;
using MudahMed.Common.ConfigSetting;
using MudahMed.Common.Constants;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel;
using MudahMed.Data.ViewModel.Bank;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/authorization")]
    [Route("admin/bank")]
    public class BankController : Controller
    {
        private readonly DataDbContext _context;
        private readonly int _maxResultLimit;

        public BankController(DataDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
        }
        
        [Route("list-banks")]
        [HttpGet]
        public async Task<IActionResult> ListBanks(string searchName)
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

        [Route("create-bank")]
        [HttpGet]
        public IActionResult CreateBank()
        {
            return View();
        }

        // POST: BankController/Create
        [ValidateAntiForgeryToken]
        [Route("create-bank")]
        [HttpPost]
        public async Task<IActionResult> CreateBank(BankViewModel model)
        {
            if (ModelState.IsValid)
            {
                Bank bank = new Bank
                {
                    Bank_name = model.BankName,
                    IsDisplay = true
                };


                _context.Banks.Add(bank);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListBanks");

            }

            return View(model);
        }

        [Route("edit-bank/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditBank(int id)
        {

            var bank = _context.Banks.Where(u => u.Bank_id == id).First();


            var model = new BankViewModel
            {
                BankID = bank.Bank_id,
                BankName = bank.Bank_name,
                IsDisplay = bank.IsDisplay
            };


            return View(model);
        }

        [Route("edit-bank/{BankID}")]
        [HttpPost]
        public async Task<IActionResult> EditBank(BankViewModel model)
        {
            if (ModelState.IsValid)
            {
                Bank bank = _context.Banks.Where(u => u.Bank_id == model.BankID).First();
                bank.Bank_name = model.BankName;
                bank.IsDisplay = model.IsDisplay;
                _context.Banks.Update(bank);
                await _context.SaveChangesAsync();

                return RedirectToAction("ListBanks");
            }

            return View(model);
        }

        //[Route("delete-bank/{BankID}")]
        [Route("delete-bank")]
        [HttpGet]
        public async Task<IActionResult> DeleteBank(int BankID)
        {
            try
            {
                Bank bankHere = _context.Banks.Where(u => u.Bank_id == BankID).First();

                if (bankHere == null)
                {
                    ViewBag.ErrorMessage = $"Bank with Id = {BankID} cannot be found";
                    return View("NotFound");
                }
                else
                {
                    _context.Banks.Remove(bankHere);
                    _context.SaveChanges();
                    return RedirectToAction("ListBanks");
                }

            }
            catch (System.Exception)
            {
                return View("NotFound");
            }
        }
    }
}
