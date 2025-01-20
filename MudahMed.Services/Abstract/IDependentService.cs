using MudahMed.Data.ViewModel.Dep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services.Abstract
{
    public interface IDependentService
    {
        Task<IQueryable<DependentViewModel>> GetAllDependents();
        Task<DependentViewModel> GetDependentByIdAsync(int id);
        Task CreateDependentAsync(DependentViewModel model);
        Task UpdateDependentAsync(DependentViewModel model);
        Task DeleteDependentAsync(int id);
    }
}
