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

        public async Task<IList<ClinicViewModel>> GetAllClinicsAsync()
        {
            return await Task.Run(() => _clinicRepository.GetClinics());
        }

        public async Task<ClinicViewModel> GetClinicByIdAsync(int id)
        {
            return await Task.Run(() => _clinicRepository.GetClinicById(id));
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
