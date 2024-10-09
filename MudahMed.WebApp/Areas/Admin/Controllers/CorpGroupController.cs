using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MudahMed.Common.ConfigSetting;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.ViewModel;

namespace MudahMed.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/corpgroup")]
    public class CorpGroupController : Controller
    {
        private readonly DataDbContext _context;
        private readonly int _maxResultLimit;
        // GET: CorpGroupController
        public CorpGroupController(DataDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
        }

        [Route("list-corpgroup")]
        [HttpGet]
        public IActionResult ListCorpGroup(string corpGroupName)
        {
            //employer count
            var corpGroups = _context.CorpGroups.AsQueryable();

            if (!String.IsNullOrEmpty(corpGroupName))
                corpGroups = corpGroups.Where(c => c.Name.Contains(corpGroupName));
            else
              corpGroups = corpGroups.Take(_maxResultLimit);

            return View(corpGroups);
        }

        // GET: CorpGroupController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CorpGroupController/CreateCorpGroup
        [Route("create")]
        public IActionResult CreateCorpGroup()
        {
            return View();
        }

        // POST: CorpGroupController/Create
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

        // GET: CorpGroupController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CorpGroupController/Edit/5
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

        // GET: CorpGroupController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CorpGroupController/Delete/5
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
