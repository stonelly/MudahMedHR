using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DiagnosisRepository(DataDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // Get all Diagnosis

        public Task<IQueryable<DiagnosisViewModel>> GetDiagnosis()
        {
            return Task.FromResult(_context.Diagnosis
                .Select(d => new DiagnosisViewModel
                {
                    Diag_id = d.Diag_id,
                    Diag_cat = d.Diag_cat,
                    Diag_desc = d.Diag_desc,
                    IsRemarksReq = d.IsRemarksReq,
                    IsActive = d.IsActive,
                    IsLTM = d.IsLTM,
                    IsGP = d.IsGP ?? false,
                    DiagGrp = d.DiagGrp
                }));
        }

        // Get a diagnosis by ID
        public async Task<DiagnosisViewModel> GetDiagnosisById(string id)
        {
            var diagnosis = await _context.Diagnosis.FindAsync(id);
            if (diagnosis == null) return new DiagnosisViewModel();

            return new DiagnosisViewModel
            {
                Diag_id = diagnosis.Diag_id,
                Diag_cat = diagnosis.Diag_cat,
                Diag_desc = diagnosis.Diag_desc,
                IsRemarksReq = diagnosis.IsRemarksReq,
                IsActive = diagnosis.IsActive,
                IsLTM = diagnosis.IsLTM,
                IsGP = diagnosis.IsGP ?? false,
                DiagGrp = diagnosis.DiagGrp
            };
        }

        // Create a new diagnosis
        public async Task CreateDiagnosisAsync(DiagnosisViewModel model)
        {
            var diagnosis = new Diagnosis
            {
                Diag_id = model.Diag_id,
                Diag_cat = model.Diag_cat,
                Diag_desc = model.Diag_desc,
                IsRemarksReq = model.IsRemarksReq,
                IsActive = true,
                IsLTM = model.IsLTM,
                IsGP = model.IsGP,
                DiagGrp = model.DiagGrp
            };

            await _context.Diagnosis.AddAsync(diagnosis);
            await _context.SaveChangesAsync();
        }

        // Update an existing diagnosis
        public async Task UpdateDiagnosisAsync(DiagnosisViewModel model)
        {
            var diagnosis = await _context.Diagnosis.FindAsync(model.Diag_id);
            if (diagnosis == null) return;

            diagnosis.Diag_cat = model.Diag_cat;
            diagnosis.Diag_desc = model.Diag_desc;
            diagnosis.IsRemarksReq = model.IsRemarksReq;
            diagnosis.IsActive = model.IsActive;
            diagnosis.IsLTM = model.IsLTM;
            diagnosis.IsGP = model.IsGP;
            diagnosis.DiagGrp = model.DiagGrp;

            await _context.SaveChangesAsync();
        }
    }
}
