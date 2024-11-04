using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.CorpGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories
{
    public class CorpGroupRepository : ICorpGroupRepository
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CorpGroupRepository(DataDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // Get all corp groups
        public Task<IQueryable<CorpGroupViewModel>> GetCorpGroups()
        {
            return Task.FromResult(_context.CorpGroups
                .Select(cg => new CorpGroupViewModel
                {
                    CorpGroupID = cg.CorpGroupID,
                    Name = cg.Name,
                    Addr1 = cg.Addr1,
                    Addr2 = cg.Addr2,
                    Addr3 = cg.Addr3,
                    postcode = cg.postcode,
                    city = cg.city,
                    state = cg.state,
                    country = cg.country,
                    ContactPerson = cg.ContactPerson,
                    ContactNo = cg.ContactNo,
                    Fax = cg.Fax,
                    RegNo = cg.RegNo,
                    TIN = cg.TIN,
                    BankID = cg.BankID,
                    BankAccNo = cg.BankAccNo,
                    Email = cg.Email,
                    IsActive = cg.IsActive ?? false,
                    createdDate = cg.createdDate,
                    LastModifiedBy = cg.LastModifiedBy,
                    LastModifiedDate = cg.LastModifiedDate
                }));
        }

        // Get a corp group by ID
        public async Task<CorpGroupViewModel> GetCorpGroupById(int id)
        {
            var corpGroup = await _context.CorpGroups.FindAsync(id);
            if (corpGroup == null) return new CorpGroupViewModel();

            return new CorpGroupViewModel
            {
                CorpGroupID = corpGroup.CorpGroupID,
                Name = corpGroup.Name,
                Addr1 = corpGroup.Addr1,
                Addr2 = corpGroup.Addr2,
                Addr3 = corpGroup.Addr3,
                postcode = corpGroup.postcode,
                city = corpGroup.city,
                state = corpGroup.state,
                country = corpGroup.country,
                ContactPerson = corpGroup.ContactPerson,
                ContactNo = corpGroup.ContactNo,
                Fax = corpGroup.Fax,
                RegNo = corpGroup.RegNo,
                TIN = corpGroup.TIN,
                BankID = corpGroup.BankID,
                BankAccNo = corpGroup.BankAccNo,
                Email = corpGroup.Email,
                IsActive = corpGroup.IsActive ?? false,
                createdDate = corpGroup.createdDate,
                LastModifiedBy = corpGroup.LastModifiedBy,
                LastModifiedDate = corpGroup.LastModifiedDate
            };
        }

        // Create a new corp group
        public async Task CreateCorpGroupAsync(CorpGroupViewModel model)
        {
            var corpGroup = new CorpGroup
            {
                Name = model.Name,
                Addr1 = model.Addr1,
                Addr2 = model.Addr2,
                Addr3 = model.Addr3,
                postcode = model.postcode,
                city = model.city,
                state = model.state,
                country = model.country,
                ContactPerson = model.ContactPerson,
                ContactNo = model.ContactNo,
                Fax = model.Fax,
                RegNo = model.RegNo,
                TIN = model.TIN,
                BankID = model.BankID,
                BankAccNo = model.BankAccNo,
                Email = model.Email,
                IsActive = true,
                createdDate = DateTime.Now,
                LastModifiedBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User)
            };

            await _context.CorpGroups.AddAsync(corpGroup);
            await _context.SaveChangesAsync();
        }

        // Update an existing corp group
        public async Task UpdateCorpGroupAsync(CorpGroupViewModel model)
        {
            var corpGroup = await _context.CorpGroups.FindAsync(model.CorpGroupID);
            if (corpGroup == null) return;

            corpGroup.Name = model.Name;
            corpGroup.Addr1 = model.Addr1;
            corpGroup.Addr2 = model.Addr2;
            corpGroup.Addr3 = model.Addr3;
            corpGroup.postcode = model.postcode;
            corpGroup.city = model.city;
            corpGroup.state = model.state;
            corpGroup.country = model.country;
            corpGroup.ContactPerson = model.ContactPerson;
            corpGroup.ContactNo = model.ContactNo;
            corpGroup.Fax = model.Fax;
            corpGroup.RegNo = model.RegNo;
            corpGroup.TIN = model.TIN;
            corpGroup.BankID = model.BankID;
            corpGroup.BankAccNo = model.BankAccNo;
            corpGroup.Email = model.Email;
            corpGroup.IsActive  = model.IsActive;
            corpGroup.LastModifiedBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            corpGroup.LastModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }

}
