using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudahMed.Data.DataContext;
using X.PagedList;

namespace MudahMed.WebApp.Controllers
{
    [Route("company")]
    public class CompanyController : Controller
    {
        private readonly DataDbContext _context;

        public CompanyController(DataDbContext context)
        {
            _context = context;
        }

        [Route("")]
        public IActionResult Index(int? page)
        {
            int pageSize = 7; //number of employers per page
            var random = new Random();


            var employers = _context.AppUsers
                .Where(e => e.Status == 2)
                //.Include(e => e.Country)
                .ToList();

            int pageNumber = page ?? 1; // Trang hiện tại
            ViewBag.StartRank = (pageNumber - 1) * pageSize + 1; // Xếp hạng bắt đầu của employers trên trang hiện tại

            return View(employers.ToPagedList(pageNumber, pageSize));

        }

        [Route("{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            var random = new Random();


            var employer = await _context.AppUsers
                //.Where(e => e.Slug == slug)
                //.Include(e => e.Province)
                //.Include(e => e.Country)
                .FirstOrDefaultAsync();
            
            await _context.SaveChangesAsync();

            return View(employer);
        }
    }
}