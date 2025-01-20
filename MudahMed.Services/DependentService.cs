using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.Dep;
using MudahMed.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services
{
    public class DependentService : IDependentService
    {
        private readonly IDependentRepository _dependentRepository;

        public DependentService(IDependentRepository dependentRepository)
        {
            _dependentRepository = dependentRepository;
        }

        public async Task<IQueryable<DependentViewModel>> GetAllDependents()
        {
            return await _dependentRepository.GetDependents();
        }

        public async Task<DependentViewModel> GetDependentByIdAsync(int id)
        {
            return await _dependentRepository.GetDependentById(id);
        }

        public async Task CreateDependentAsync(DependentViewModel model)
        {
            await _dependentRepository.CreateDependentAsync(model);
        }

        public async Task UpdateDependentAsync(DependentViewModel model)
        {
            await _dependentRepository.UpdateDependentAsync(model);
        }

        public async Task DeleteDependentAsync(int id)
        {
            await _dependentRepository.DeleteDependentAsync(id);
        }
    }
}
