using MudahMed.Data.ViewModel.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories.Abstract
{
    public interface IDrugRepository
    {
        Task<IQueryable<DrugViewModel>> GetDrugs();
        Task<DrugViewModel> GetDrugById(string id);
        Task CreateDrugAsync(DrugViewModel model);
        Task UpdateDrugAsync(DrugViewModel model);
    }
}
