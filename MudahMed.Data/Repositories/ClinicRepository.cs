using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MudahMed.Data.DataContext;
using MudahMed.Data.Entities;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClinicRepository(DataDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<IQueryable<ClinicViewModel>> GetClinicsAsync()
        {
            return Task.FromResult(_context.Clinics
                .Select(c => new ClinicViewModel
                {
                    ClinicID = c.ClinicID,
                    ClinicName = c.Clinic_name ?? string.Empty,
                    ClinicAddr1 = c.Clinic_addr1,
                    ClinicAddr2 = c.Clinic_addr2,
                    ClinicAddr3 = c.Clinic_addr3,
                    Postcode = c.postcode,
                    City = c.city ?? string.Empty,
                    State = c.state,
                    Country = c.country,
                    ContactPerson = c.ContactPerson,
                    ClinicContactNo = c.Corp_ContactNo,
                    ClinicFax = c.Corp_fax,
                    ClinicRegNo = c.Corp_RegNo,
                    ClinicTIN = c.Corp_TIN,
                    BankID = c.BankID,
                    BankAccNo = c.BankAccNo,
                    IsActive = c.IsActive,
                    RecruitDate = c.RecruitDate,
                    RemovedDate = c.RemovedDate,
                    ClinicGroup = c.ClinicGroup,
                    Latitude = c.Latitude,
                    Longitude = c.Longitude,
                    Is24Hour = c.Is24Hour ?? false,
                    RenderedService = c.rendered_svc,
                    PanelType = c.panel_type,
                    PayeeName = c.PayeeName,
                    Handphone = c.Handphone,
                    ClinicEmail = c.Email,
                    ClinicContMMC = c.Clinic_cont_MMC,
                    PermanentDoc1 = c.PermenantDoc1,
                    PermanentDoc1MMC = c.PermenantDoc1MMC,
                    PermanentDoc2 = c.PermenantDoc2,
                    PermanentDoc2MMC = c.PermenantDoc2MMC,
                    LocumDoc1 = c.LocumDoc1,
                    LocumDoc1MMC = c.LocumDoc1MMC,
                    LocumDoc2 = c.LocumDoc2,
                    LocumDoc2MMC = c.LocumDoc2MMC,
                    ClinicContOHD = c.Clinic_cont_OHD,
                    PermanentDoc1OHD = c.PermenantDoc1OHD,
                    PermanentDoc2OHD = c.PermenantDoc2OHD,
                    LocumDoc1OHD = c.LocumDoc1OHD,
                    LocumDoc2OHD = c.LocumDoc2OHD,
                    SSMNo = c.SSMNo,
                    IsPCD = c.IsPCD ?? false,
                    IsIVD = c.IsIVD ?? false,
                    IsOT = c.IsOT ?? false,
                    IsCPR = c.IsCPR ?? false,
                    IsENT = c.IsENT ?? false,
                    IsUFEME = c.IsUFEME ?? false        ,
                    IsAvailAN = c.IsAvailAN ?? false,
                    IsAvailMS = c.IsAvailMS ?? false,
                    IsAvailMC = c.IsAvailMC ?? false,
                    IsSpiro = c.IsSpiro ?? false,
                    IsAudF = c.IsAudF ?? false,
                    IsLocDoc = c.IsLocDoc ?? false,
                    IsOHDDoc = c.IsOHDDoc == null ? false : (bool)c.IsOHDDoc,
                    IsECG = c.IsECG ?? false,
                    IsFBHAM = c.IsFBHAM ?? false,
                    IsAvailFMDoc = c.IsAvailFMDoc ?? false,
                    IsNebulizer = c.IsNebulizer ?? false,
                    IsUltraSound = c.IsUltraSound ?? false,
                    IsPapSme = c.IsPapSme ?? false,
                    IsXrayReader = c.IsXrayReader ?? false,
                    IsXray = c.IsXray ?? false,
                    LastModifiedBy = c.LastModifiedBy,
                    LastModifiedDate = c.LastModifiedDate
                }));
        }

        // Get a clinic by ID
        public async Task<ClinicViewModel> GetClinicById(int id)
        {
            var clinic = await _context.Clinics.FindAsync(id);
            String lastModidy = string.Empty;

            if (clinic == null) return null;

            if (!String.IsNullOrEmpty(clinic.LastModifiedBy))
            {
                var user = await _userManager.FindByIdAsync(clinic.LastModifiedBy);
                lastModidy = user?.FullName; // Returns the username or null if not found
            }
            return new ClinicViewModel
            {
                ClinicID = clinic.ClinicID,
                ClinicName = clinic.Clinic_name,
                ClinicAddr1 = clinic.Clinic_addr1,
                ClinicAddr2 = clinic.Clinic_addr2,
                ClinicAddr3 = clinic.Clinic_addr3,
                Postcode = clinic.postcode,
                City = clinic.city,
                State = clinic.state,
                Country = clinic.country,
                ContactPerson = clinic.ContactPerson,
                ClinicContactNo = clinic.Corp_ContactNo,
                ClinicFax = clinic.Corp_fax,
                ClinicRegNo = clinic.Corp_RegNo,
                ClinicTIN = clinic.Corp_TIN,
                BankID = clinic.BankID,
                BankAccNo = clinic.BankAccNo,
                IsActive = clinic.IsActive,
                RecruitDate = clinic.RecruitDate,
                RemovedDate = clinic.RemovedDate,
                ClinicGroup = clinic.ClinicGroup,
                Latitude = clinic.Latitude,
                Longitude = clinic.Longitude,
                Is24Hour = clinic.Is24Hour == null ? false : (bool)clinic.Is24Hour,
                RenderedService = clinic.rendered_svc,
                PanelType = clinic.panel_type,
                PayeeName = clinic.PayeeName,
                Handphone = clinic.Handphone,
                ClinicEmail = clinic.Email,
                ClinicContMMC = clinic.Clinic_cont_MMC,
                PermanentDoc1 = clinic.PermenantDoc1,
                PermanentDoc1MMC = clinic.PermenantDoc1MMC,
                PermanentDoc2 = clinic.PermenantDoc2,
                PermanentDoc2MMC = clinic.PermenantDoc2MMC,
                LocumDoc1 = clinic.LocumDoc1,
                LocumDoc1MMC = clinic.LocumDoc1MMC,
                LocumDoc2 = clinic.LocumDoc2,
                LocumDoc2MMC = clinic.LocumDoc2MMC,
                ClinicContOHD = clinic.Clinic_cont_OHD,
                PermanentDoc1OHD = clinic.PermenantDoc1OHD,
                PermanentDoc2OHD = clinic.PermenantDoc2OHD,
                LocumDoc1OHD = clinic.LocumDoc1OHD,
                LocumDoc2OHD = clinic.LocumDoc2OHD,
                SSMNo = clinic.SSMNo,
                IsPCD = clinic.IsPCD == null ? false : (bool)clinic.IsPCD,
                IsIVD = clinic.IsIVD == null ? false : (bool)clinic.IsIVD,
                IsOT = clinic.IsOT == null ? false : (bool)clinic.IsOT,
                IsCPR = clinic.IsCPR == null ? false : (bool)clinic.IsCPR,
                IsENT = clinic.IsENT == null ? false : (bool)clinic.IsENT,
                IsUFEME = clinic.IsUFEME == null ? false : (bool)clinic.IsUFEME,
                IsAvailAN = clinic.IsAvailAN == null ? false : (bool)clinic.IsAvailAN,
                IsAvailMS = clinic.IsAvailMS == null ? false : (bool)clinic.IsAvailMS,
                IsAvailMC = clinic.IsAvailMC == null ? false : (bool)clinic.IsAvailMC,
                IsSpiro = clinic.IsSpiro == null ? false : (bool)clinic.IsSpiro,
                IsAudF = clinic.IsAudF == null ? false : (bool)clinic.IsAudF,
                IsLocDoc = clinic.IsLocDoc == null ? false : (bool)clinic.IsLocDoc,
                IsOHDDoc = clinic.IsOHDDoc == null ? false : (bool)clinic.IsOHDDoc,
                IsECG = clinic.IsECG == null ? false : (bool)clinic.IsECG,
                IsFBHAM = clinic.IsFBHAM == null ? false : (bool)clinic.IsFBHAM,
                IsAvailFMDoc = clinic.IsAvailFMDoc == null ? false : (bool)clinic.IsAvailFMDoc,
                IsNebulizer = clinic.IsNebulizer == null ? false : (bool)clinic.IsNebulizer,
                IsUltraSound = clinic.IsUltraSound == null ? false : (bool)clinic.IsUltraSound,
                IsPapSme = clinic.IsPapSme == null ? false : (bool)clinic.IsPapSme,
                IsXrayReader = clinic.IsXrayReader == null ? false : (bool)clinic.IsXrayReader,
                IsXray = clinic.IsXray == null ? false : (bool)clinic.IsXray,
                LastModifiedBy = lastModidy,
                LastModifiedDate = clinic.LastModifiedDate
            };
        }

        // Create a new clinic
        public async Task CreateClinicAsync(ClinicViewModel model)
        {
            // Get the currently logged-in user
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (currentUser != null)
            {
                model.LastModifiedBy = currentUser.Id.ToString(); // or use currentUser.Id if needed
            }

            var clinic = new Clinic
            {
                Clinic_name = model.ClinicName,
                Clinic_addr1 = model.ClinicAddr1,
                Clinic_addr2 = model.ClinicAddr2,
                Clinic_addr3 = model.ClinicAddr3,
                postcode = model.Postcode,
                city = model.City,
                state = model.State,
                country = model.Country,
                ContactPerson = model.ContactPerson,
                Corp_ContactNo = model.ClinicContactNo,
                Corp_fax = model.ClinicFax,
                Corp_RegNo = model.ClinicRegNo,
                Corp_TIN = model.ClinicTIN,
                BankID = model.BankID,
                BankAccNo = model.BankAccNo,
                IsActive = true,
                RecruitDate = model.RecruitDate,
                RemovedDate = model.RemovedDate,
                ClinicGroup = model.ClinicGroup,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Is24Hour = model.Is24Hour,
                rendered_svc = model.RenderedService,
                panel_type = model.PanelType,
                PayeeName = model.PayeeName,
                Handphone = model.Handphone,
                Email = model.ClinicEmail,
                Clinic_cont_MMC = model.ClinicContMMC,
                PermenantDoc1 = model.PermanentDoc1,
                PermenantDoc1MMC = model.PermanentDoc1MMC,
                PermenantDoc2 = model.PermanentDoc2,
                PermenantDoc2MMC = model.PermanentDoc2MMC,
                LocumDoc1 = model.LocumDoc1,
                LocumDoc1MMC = model.LocumDoc1MMC,
                LocumDoc2 = model.LocumDoc2,
                LocumDoc2MMC = model.LocumDoc2MMC,
                Clinic_cont_OHD = model.ClinicContOHD,
                PermenantDoc1OHD = model.PermanentDoc1OHD,
                PermenantDoc2OHD = model.PermanentDoc2OHD,
                LocumDoc1OHD = model.LocumDoc1OHD,
                LocumDoc2OHD = model.LocumDoc2OHD,
                SSMNo = model.SSMNo,
                IsPCD = model.IsPCD,
                IsIVD = model.IsIVD,
                IsOT = model.IsOT,
                IsCPR = model.IsCPR,
                IsENT = model.IsENT,
                IsUFEME = model.IsUFEME,
                IsAvailAN = model.IsAvailAN,
                IsAvailMS = model.IsAvailMS,
                IsAvailMC = model.IsAvailMC,
                IsSpiro = model.IsSpiro,
                IsAudF = model.IsAudF,
                IsLocDoc = model.IsLocDoc,
                IsOHDDoc = model.IsOHDDoc,
                IsECG = model.IsECG,
                IsFBHAM = model.IsFBHAM,
                IsAvailFMDoc = model.IsAvailFMDoc,
                IsNebulizer = model.IsNebulizer,
                IsUltraSound = model.IsUltraSound,
                IsPapSme = model.IsPapSme,
                IsXrayReader = model.IsXrayReader,
                IsXray = model.IsXray,
                LastModifiedBy = model.LastModifiedBy,
                LastModifiedDate = DateTime.Now
            };

            await _context.Clinics.AddAsync(clinic);
            await _context.SaveChangesAsync();
        }

        // Update an existing clinic
        public async Task UpdateClinicAsync(ClinicViewModel model)
        {
            var clinic = await _context.Clinics.FindAsync(model.ClinicID);
            if (clinic == null) return;

            // Get the currently logged-in user
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (currentUser != null)
            {
                model.LastModifiedBy = currentUser.Id.ToString(); // or use currentUser.Id if needed
            }

            clinic.Clinic_name = model.ClinicName;
            clinic.Clinic_addr1 = model.ClinicAddr1;
            clinic.Clinic_addr2 = model.ClinicAddr2;
            clinic.Clinic_addr3 = model.ClinicAddr3;
            clinic.postcode = model.Postcode;
            clinic.city = model.City;
            clinic.state = model.State;
            clinic.country = model.Country;
            clinic.ContactPerson = model.ContactPerson;
            clinic.Corp_ContactNo = model.ClinicContactNo;
            clinic.Corp_fax = model.ClinicFax;
            clinic.Corp_RegNo = model.ClinicRegNo;
            clinic.Corp_TIN = model.ClinicTIN;
            clinic.BankID = model.BankID;
            clinic.BankAccNo = model.BankAccNo;
            clinic.IsActive = model.IsActive;
            clinic.RecruitDate = model.RecruitDate;
            clinic.RemovedDate = model.RemovedDate;
            clinic.ClinicGroup = model.ClinicGroup;
            clinic.Latitude = model.Latitude;
            clinic.Longitude = model.Longitude;
            clinic.Is24Hour = model.Is24Hour;
            clinic.rendered_svc = model.RenderedService;
            clinic.panel_type = model.PanelType;
            clinic.PayeeName = model.PayeeName;
            clinic.Handphone = model.Handphone;
            clinic.Email = model.ClinicEmail;
            clinic.Clinic_cont_MMC = model.ClinicContMMC;
            clinic.PermenantDoc1 = model.PermanentDoc1;
            clinic.PermenantDoc1MMC = model.PermanentDoc1MMC;
            clinic.PermenantDoc2 = model.PermanentDoc2;
            clinic.PermenantDoc2MMC = model.PermanentDoc2MMC;
            clinic.LocumDoc1 = model.LocumDoc1;
            clinic.LocumDoc1MMC = model.LocumDoc1MMC;
            clinic.LocumDoc2 = model.LocumDoc2;
            clinic.LocumDoc2MMC = model.LocumDoc2MMC;
            clinic.Clinic_cont_OHD = model.ClinicContOHD;
            clinic.PermenantDoc1OHD = model.PermanentDoc1OHD;
            clinic.PermenantDoc2OHD = model.PermanentDoc2OHD;
            clinic.LocumDoc1OHD = model.LocumDoc1OHD;
            clinic.LocumDoc2OHD = model.LocumDoc2OHD;
            clinic.SSMNo = model.SSMNo;
            clinic.IsPCD = model.IsPCD;
            clinic.IsIVD = model.IsIVD;
            clinic.IsOT = model.IsOT;
            clinic.IsCPR = model.IsCPR;
            clinic.IsENT = model.IsENT;
            clinic.IsUFEME = model.IsUFEME;
            clinic.IsAvailAN = model.IsAvailAN;
            clinic.IsAvailMS = model.IsAvailMS;
            clinic.IsAvailMC = model.IsAvailMC;
            clinic.IsSpiro = model.IsSpiro;
            clinic.IsAudF = model.IsAudF;
            clinic.IsLocDoc = model.IsLocDoc;
            clinic.IsOHDDoc = model.IsOHDDoc;
            clinic.IsECG = model.IsECG;
            clinic.IsFBHAM = model.IsFBHAM;
            clinic.IsAvailFMDoc = model.IsAvailFMDoc;
            clinic.IsNebulizer = model.IsNebulizer;
            clinic.IsUltraSound = model.IsUltraSound;
            clinic.IsPapSme = model.IsPapSme;
            clinic.IsXrayReader = model.IsXrayReader;
            clinic.IsXray = model.IsXray;
            clinic.LastModifiedDate = DateTime.Now;
            clinic.LastModifiedBy = model.LastModifiedBy;

            await _context.SaveChangesAsync();
        }
    }
}