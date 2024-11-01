using MudahMed.Data.ViewModel.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services.Abstract
{
    public interface IDrugService
    {
        Task<IQueryable<DrugViewModel>> GetAllDrugs();
        Task<DrugViewModel> GetDrugByIdAsync(string id);
        Task CreateDrugAsync(DrugViewModel model);
        Task UpdateDrugAsync(DrugViewModel model);
    }

}
