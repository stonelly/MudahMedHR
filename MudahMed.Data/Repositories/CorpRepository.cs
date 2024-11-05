using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.Corporate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories
{
    public class CorpRepository : ICorpRepository
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CorpRepository(DataDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // Get all corps
        public Task<IQueryable<CorpViewModel>> GetCorps()
        {
            return Task.FromResult(_context.Corps
                .Select(c => new CorpViewModel
                {
                    CorpID = c.CorpID,
                    Corp_name = c.Corp_name,
                    Corp_addr1 = c.Corp_addr1,
                    Corp_addr2 = c.Corp_addr2,
                    Corp_addr3 = c.Corp_addr3,
                    postcode = c.postcode,
                    city = c.city,
                    state = c.state,
                    country = c.country,
                    ContactPerson = c.ContactPerson,
                    Corp_ContactNo = c.Corp_ContactNo,
                    Corp_fax = c.Corp_fax,
                    Corp_RegNo = c.Corp_RegNo,
                    Corp_TIN = c.Corp_TIN,
                    BankID = c.BankID,
                    BankAccNo = c.BankAccNo,
                    CorpGroupID = c.CorpGroupID,
                    Email = c.Email,
                    FinanceEmail = c.FinanceEmail,
                    IsSuspend = c.IsSuspend,
                    IndustryField = c.IndustryField,
                    IsActive = c.IsActive ?? false,
                    createdDate = c.createdDate,
                    LastModifiedBy = c.LastModifiedBy,
                    LastModifiedDate = c.LastModifiedDate
                }));
        }

        // Get a corp by ID
        public async Task<CorpViewModel> GetCorpById(int id)
        {
            var corp = await _context.Corps.FindAsync(id);
            if (corp == null) return new CorpViewModel();

            return new CorpViewModel
            {
                CorpID = corp.CorpID,
                Corp_name = corp.Corp_name,
                Corp_addr1 = corp.Corp_addr1,
                Corp_addr2 = corp.Corp_addr2,
                Corp_addr3 = corp.Corp_addr3,
                postcode = corp.postcode,
                city = corp.city,
                state = corp.state,
                country = corp.country,
                ContactPerson = corp.ContactPerson,
                Corp_ContactNo = corp.Corp_ContactNo,
                Corp_fax = corp.Corp_fax,
                Corp_RegNo = corp.Corp_RegNo,
                Corp_TIN = corp.Corp_TIN,
                BankID = corp.BankID,
                BankAccNo = corp.BankAccNo,
                CorpGroupID = corp.CorpGroupID,
                Email = corp.Email,
                FinanceEmail = corp.FinanceEmail,
                IsSuspend = corp.IsSuspend,
                IndustryField = corp.IndustryField,
                IsActive = corp.IsActive ?? false,
                createdDate = corp.createdDate,
                LastModifiedBy = corp.LastModifiedBy,
                LastModifiedDate = corp.LastModifiedDate
            };
        }

        // Create a new corp
        public async Task CreateCorpAsync(CorpViewModel model)
        {
            var corp = new Corp
            {
                Corp_name = model.Corp_name,
                Corp_addr1 = model.Corp_addr1,
                Corp_addr2 = model.Corp_addr2,
                Corp_addr3 = model.Corp_addr3,
                postcode = model.postcode,
                city = model.city,
                state = model.state,
                country = model.country,
                ContactPerson = model.ContactPerson,
                Corp_ContactNo = model.Corp_ContactNo,
                Corp_fax = model.Corp_fax,
                Corp_RegNo = model.Corp_RegNo,
                Corp_TIN = model.Corp_TIN,
                BankID = model.BankID,
                BankAccNo = model.BankAccNo,
                CorpGroupID = model.CorpGroupID,
                Email = model.Email,
                FinanceEmail = model.FinanceEmail,
                IsSuspend = model.IsSuspend,
                IndustryField = model.IndustryField,
                IsActive = true,
                createdDate = DateTime.Now,
                LastModifiedBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User)
            };

            await _context.Corps.AddAsync(corp);
            await _context.SaveChangesAsync();
        }

        // Update an existing corp
        public async Task UpdateCorpAsync(CorpViewModel model)
        {
            var corp = await _context.Corps.FindAsync(model.CorpID);
            if (corp == null) return;

            corp.Corp_name = model.Corp_name;
            corp.Corp_addr1 = model.Corp_addr1;
            corp.Corp_addr2 = model.Corp_addr2;
            corp.Corp_addr3 = model.Corp_addr3;
            corp.postcode = model.postcode;
            corp.city = model.city;
            corp.state = model.state;
            corp.country = model.country;
            corp.ContactPerson = model.ContactPerson;
            corp.Corp_ContactNo = model.Corp_ContactNo;
            corp.Corp_fax = model.Corp_fax;
            corp.Corp_RegNo = model.Corp_RegNo;
            corp.Corp_TIN = model.Corp_TIN;
            corp.BankID = model.BankID;
            corp.BankAccNo = model.BankAccNo;
            corp.CorpGroupID = model.CorpGroupID;
            corp.Email = model.Email;
            corp.FinanceEmail = model.FinanceEmail;
            corp.IsSuspend = model.IsSuspend;
            corp.IndustryField = model.IndustryField;
            corp.IsActive = model.IsActive;
            corp.LastModifiedBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            corp.LastModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }

}
