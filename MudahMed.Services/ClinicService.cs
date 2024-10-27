using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.Clinic;
using MudahMed.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicService(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public async Task<IQueryable<ClinicViewModel>> GetAllClinicsAsync()
        {
            return await _clinicRepository.GetClinicsAsync();
        }

        public async Task<ClinicViewModel> GetClinicByIdAsync(int id)
        {
            return await _clinicRepository.GetClinicById(id);
        }

        public async Task CreateClinicAsync(ClinicViewModel model)
        {
            await _clinicRepository.CreateClinicAsync(model);
        }

        public async Task UpdateClinicAsync(ClinicViewModel model)
        {
            await _clinicRepository.UpdateClinicAsync(model);
        }
    }

}
