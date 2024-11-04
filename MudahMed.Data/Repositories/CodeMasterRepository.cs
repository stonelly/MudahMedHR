using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories
{
    public class CodeMasterRepository : ICodeMasterRepository
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CodeMasterRepository(DataDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // Get all master codes
        public Task<IQueryable<CodeMasterViewModel>> GetCodeMasters()
        {
            return Task.FromResult(_context.CodeMasters
                .Select(mc => new CodeMasterViewModel
                {
                    CodeMaster_id = mc.CodeMaster_id,
                    CodeType = mc.CodeType,
                    CodeValue = mc.CodeValue,
                    CodeDescription = mc.CodeDescription,
                    Sequence = mc.Sequence,
                    IsActive = mc.IsActive ?? false,
                    CreatedDateBy = mc.CreatedDateBy,
                    CreatedDate = mc.CreatedDate,
                    LastModifiedBy = mc.LastModifiedBy,
                    LastModifiedDate = mc.LastModifiedDate
                }));
        }
        public  Task<IQueryable<CodeMasterViewModel>> GetCodeMastersByType(string codeType)
        {
            return Task.FromResult(_context.CodeMasters
                .Select(mc => new CodeMasterViewModel
                {
                    CodeMaster_id = mc.CodeMaster_id,
                    CodeType = mc.CodeType,
                    CodeValue = mc.CodeValue,
                    CodeDescription = mc.CodeDescription,
                    Sequence = mc.Sequence,
                    IsActive = mc.IsActive ?? false,
                    CreatedDateBy = mc.CreatedDateBy,
                    CreatedDate = mc.CreatedDate,
                    LastModifiedBy = mc.LastModifiedBy,
                    LastModifiedDate = mc.LastModifiedDate
                }).Where(c => c.CodeType.Equals(codeType) && c.IsActive == true));
        }

        // Get a master code by ID
        public async Task<CodeMasterViewModel> GetCodeMasterById(int id)
        {
            var codeMaster = await _context.CodeMasters.FindAsync(id);
            if (codeMaster == null) return new CodeMasterViewModel();

            return new CodeMasterViewModel
            {
                CodeMaster_id = codeMaster.CodeMaster_id,
                CodeType = codeMaster.CodeType,
                CodeValue = codeMaster.CodeValue,
                CodeDescription = codeMaster.CodeDescription,
                Sequence = codeMaster.Sequence,
                IsActive = codeMaster.IsActive ?? false,
                CreatedDateBy = codeMaster.CreatedDateBy,
                CreatedDate = codeMaster.CreatedDate,
                LastModifiedBy = codeMaster.LastModifiedBy,
                LastModifiedDate = codeMaster.LastModifiedDate
            };
        }

        // Create a new master code
        public async Task CreateCodeMasterAsync(CodeMasterViewModel model)
        {
            var codeMaster = new CodeMaster
            {
                CodeMaster_id = model.CodeMaster_id,
                CodeType = model.CodeType,
                CodeValue = model.CodeValue,
                CodeDescription = model.CodeDescription,
                Sequence = model.Sequence,
                IsActive = true, // Default active status
                CreatedDateBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User),
                CreatedDate = DateTime.Now
            };

            await _context.CodeMasters.AddAsync(codeMaster);
            await _context.SaveChangesAsync();
        }

        // Update an existing master code
        public async Task UpdateCodeMasterAsync(CodeMasterViewModel model)
        {
            var codeMaster = await _context.CodeMasters.FindAsync(model.CodeMaster_id);
            if (codeMaster == null) return;

            codeMaster.CodeType = model.CodeType;
            codeMaster.CodeValue = model.CodeValue;
            codeMaster.CodeDescription = model.CodeDescription;
            codeMaster.Sequence = model.Sequence;
            codeMaster.IsActive = model.IsActive;
            codeMaster.LastModifiedBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            codeMaster.LastModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }

}
