using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudahMed.Data.DataContext;
using MudahMed.WebApp.Models;
using System.Diagnostics;

namespace MudahMed.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataDbContext _context;

        public HomeController(DataDbContext dataDbContext)
        {
            this._context = dataDbContext;
        }

        public IActionResult Index()
        {
            var random = new Random();

            return View();
        }

        [Route("about-us")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("price")]
        public IActionResult Price()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("elements")]
        public IActionResult Elements()
        {
            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}