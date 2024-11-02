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
    public class DrugRepository : IDrugRepository
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DrugRepository(DataDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // Get all drugs
        public Task<IQueryable<DrugViewModel>> GetDrugs()
        {
            return Task.FromResult(_context.Drugs
                .Select(d => new DrugViewModel
                {
                    DrugID = d.DrugID,
                    DrugType_CodeFK = d.DrugType_CodeFK,
                    DrugCatFFS_CodeFK = d.DrugCatFFS_CodeFK,
                    DrugDesc = d.DrugDesc,
                    ATCClass = d.ATCClass,
                    DrugMIMSClass_CodeFK = d.DrugMIMSClass_CodeFK,
                    GenericName = d.GenericName,
                    DrugRoute_CodeFK = d.DrugRoute_CodeFK,
                    DrugUnit_CodeFK = d.DrugUnit_CodeFK,
                    ICDCode = d.ICDCode,
                    DrugChrgField_CodeFK = d.DrugChrgField_CodeFK,
                    IsActive = d.IsActive ?? false,
                    CreatedDate = d.CreatedDate,
                    CreatedBy = d.CreatedBy,
                    ModifyDate = d.ModifyDate,
                    ModifyBy = d.ModifyBy,
                    DrugPoisonFFS_CodeFK = d.DrugPoisonFFS_CodeFK,
                    UnitPrice = d.UnitPrice,
                    IsChronic = d.IsChronic ?? false,
                    MaxQty = d.MaxQty ?? 0,
                    MaxPrice = d.MaxPrice ?? 0,
                    CeilingPrice = d.CeilingPrice ?? 0,
                    IsExclusion = d.IsExclusion ?? false
                }));
        }

        // Get a drug by ID
        public async Task<DrugViewModel> GetDrugById(string id)
        {
            var drug = await _context.Drugs.FindAsync(id);
            if (drug == null) return new DrugViewModel();

            return new DrugViewModel
            {
                DrugID = drug.DrugID,
                DrugType_CodeFK = drug.DrugType_CodeFK,
                DrugCatFFS_CodeFK = drug.DrugCatFFS_CodeFK,
                DrugDesc = drug.DrugDesc,
                ATCClass = drug.ATCClass,
                DrugMIMSClass_CodeFK = drug.DrugMIMSClass_CodeFK,
                GenericName = drug.GenericName,
                DrugRoute_CodeFK = drug.DrugRoute_CodeFK,
                DrugUnit_CodeFK = drug.DrugUnit_CodeFK,
                ICDCode = drug.ICDCode,
                DrugChrgField_CodeFK = drug.DrugChrgField_CodeFK,
                IsActive = drug.IsActive ?? false,
                CreatedDate = drug.CreatedDate,
                CreatedBy = drug.CreatedBy,
                ModifyDate = drug.ModifyDate,
                ModifyBy = drug.ModifyBy,
                DrugPoisonFFS_CodeFK = drug.DrugPoisonFFS_CodeFK,
                UnitPrice = drug.UnitPrice,
                IsChronic = drug.IsChronic ?? false,
                MaxQty = drug.MaxQty ?? 0,
                MaxPrice = drug.MaxPrice ?? 0,
                CeilingPrice = drug.CeilingPrice ?? 0,
                IsExclusion = drug.IsExclusion ?? false
            };
        }

        // Create a new drug
        public async Task CreateDrugAsync(DrugViewModel model)
        {
            var drug = new Drug
            {
                DrugID = model.DrugID,
                DrugType_CodeFK = model.DrugType_CodeFK,
                DrugCatFFS_CodeFK = model.DrugCatFFS_CodeFK,
                DrugDesc = model.DrugDesc,
                ATCClass = model.ATCClass,
                DrugMIMSClass_CodeFK = model.DrugMIMSClass_CodeFK,
                GenericName = model.GenericName,
                DrugRoute_CodeFK = model.DrugRoute_CodeFK,
                DrugUnit_CodeFK = model.DrugUnit_CodeFK,
                ICDCode = model.ICDCode,
                DrugChrgField_CodeFK = model.DrugChrgField_CodeFK,
                IsActive = true, // Default active status
                CreatedDate = DateTime.Now,
                CreatedBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User),
                DrugPoisonFFS_CodeFK = model.DrugPoisonFFS_CodeFK,
                UnitPrice = model.UnitPrice,
                IsChronic = model.IsChronic,
                MaxQty = model.MaxQty,
                MaxPrice = model.MaxPrice,
                CeilingPrice = model.CeilingPrice,
                IsExclusion = model.IsExclusion
            };

            await _context.Drugs.AddAsync(drug);
            await _context.SaveChangesAsync();
        }

        // Update an existing drug
        public async Task UpdateDrugAsync(DrugViewModel model)
        {
            var drug = await _context.Drugs.FindAsync(model.DrugID);
            if (drug == null) return;

            drug.DrugType_CodeFK = model.DrugType_CodeFK;
            drug.DrugCatFFS_CodeFK = model.DrugCatFFS_CodeFK;
            drug.DrugDesc = model.DrugDesc;
            drug.ATCClass = model.ATCClass;
            drug.DrugMIMSClass_CodeFK = model.DrugMIMSClass_CodeFK;
            drug.GenericName = model.GenericName;
            drug.DrugRoute_CodeFK = model.DrugRoute_CodeFK;
            drug.DrugUnit_CodeFK = model.DrugUnit_CodeFK;
            drug.ICDCode = model.ICDCode;
            drug.DrugChrgField_CodeFK = model.DrugChrgField_CodeFK;
            drug.IsActive = model.IsActive;
            drug.ModifyDate = DateTime.Now;
            drug.ModifyBy = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            drug.DrugPoisonFFS_CodeFK = model.DrugPoisonFFS_CodeFK;
            drug.UnitPrice = model.UnitPrice;
            drug.IsChronic = model.IsChronic;
            drug.MaxQty = model.MaxQty;
            drug.MaxPrice = model.MaxPrice;
            drug.CeilingPrice = model.CeilingPrice;
            drug.IsExclusion = model.IsExclusion;

            await _context.SaveChangesAsync();
        }
    }

}
