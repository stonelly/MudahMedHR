using Microsoft.AspNetCore.Mvc;
using MudahMed.Data.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace MudahMed.WebApp.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("employer")]
    [Authorize(Roles = "Corporate")]
    public class HomeController : Controller
    {
        private readonly DataDbContext _context;

        public HomeController(DataDbContext context)
        {
            _context = context;
        }

        [Route("index/{id}")]
        [Route("{id}")]
        public IActionResult Index(Guid id, int? page)
        {
            int pageSize = 5; //number of item per page


            return View();
        }
    }
}
