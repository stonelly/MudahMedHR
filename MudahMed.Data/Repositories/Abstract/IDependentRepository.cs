using MudahMed.Data.ViewModel.Dep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories.Abstract
{
    public interface IDependentRepository
    {
        Task<IQueryable<DependentViewModel>> GetDependents();
        Task<DependentViewModel> GetDependentById(int id);
        Task CreateDependentAsync(DependentViewModel model);
        Task UpdateDependentAsync(DependentViewModel model);
        Task DeleteDependentAsync(int id);
    }
}
