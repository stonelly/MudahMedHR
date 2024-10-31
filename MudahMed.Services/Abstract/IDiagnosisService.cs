using MudahMed.Data.ViewModel.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services.Abstract
{
    public interface IDiagnosisService
    {
        Task<IQueryable<DiagnosisViewModel>> GetAllDiagnosis();
        Task<DiagnosisViewModel> GetDiagnosisByIdAsync(string id);
        Task CreateDiagnosisAsync(DiagnosisViewModel model);
        Task UpdateDiagnosisAsync(DiagnosisViewModel model);
    }
}
