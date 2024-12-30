using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using MudahMed.Data.DataContext;
using X.PagedList;
using AutoMapper;
using MudahMed.Services.Abstract;
using MudahMed.Data.ViewModel;
using MudahMed.Services;
using Microsoft.Extensions.Options;
using MudahMed.Common.ConfigSetting;
using MudahMed.Common.Constants;

namespace MudahMed.WebApp.Areas.Admin.Controllers

{
    [Area("Admin")]
    [Route("admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;
        private readonly int _maxResultLimit;

        public HomeController(DataDbContext context, IAppUserService appUserService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _context = context;
            _maxResultLimit = appSettings.Value.MaxResultLimit;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            //employer count
            var employerCount = _context.AppUsers.Count(e => e.Status == 2);
            ViewBag.CountEmployer = employerCount;

            //user count
            var userCount = _context.AppUsers.Count(u => u.Status != -1 && u.Status != 2);
            ViewBag.CountUser = userCount;


            return View();
        }
    }
}