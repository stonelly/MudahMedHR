using MudahMed.Data.ViewModel.Clinic;
using MudahMed.Data.ViewModel.Corporate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories.Abstract
{
    public interface IClinicRepository
    {
        IList<ClinicViewModel> GetClinics();
        ClinicViewModel GetClinicById(int id);
        Task CreateClinicAsync(ClinicViewModel model);
        Task UpdateClinicAsync(ClinicViewModel model);
    }
}
