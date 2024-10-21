using MudahMed.Data.ViewModel.Clinic;
using MudahMed.Data.ViewModel.Corporate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories.Abstract
{
    public interface IClinicUserRepository
    {
        Task<List<ClinicUserViewModel>> GetClinicUsersAsync();
        Task<ClinicUserViewModel> GetClinicUserByIdAsync(Guid userId);
        Task CreateClinicUserAsync(ClinicUserViewModel model);
        Task UpdateClinicUserAsync(ClinicUserViewModel model);
    }
}
