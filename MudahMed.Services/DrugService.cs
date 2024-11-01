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
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository _drugRepository;

        public DrugService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        public async Task<IQueryable<DrugViewModel>> GetAllDrugs()
        {
            return await _drugRepository.GetDrugs();
        }

        public async Task<DrugViewModel> GetDrugByIdAsync(string id)
        {
            return await _drugRepository.GetDrugById(id);
        }

        public async Task CreateDrugAsync(DrugViewModel model)
        {
            await _drugRepository.CreateDrugAsync(model);
        }

        public async Task UpdateDrugAsync(DrugViewModel model)
        {
            await _drugRepository.UpdateDrugAsync(model);
        }
    }

}
