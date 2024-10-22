using MudahMed.Data.ViewModel.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services.Abstract
{
    public interface IClinicService
    {
        Task<IList<ClinicViewModel>> GetAllClinicsAsync();
        Task<ClinicViewModel> GetClinicByIdAsync(int id);
        Task CreateClinicAsync(ClinicViewModel model);
        Task UpdateClinicAsync(ClinicViewModel model);
    }

}
