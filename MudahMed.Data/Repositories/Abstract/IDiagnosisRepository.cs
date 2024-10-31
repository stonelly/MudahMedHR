using MudahMed.Data.ViewModel.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories.Abstract
{
    public interface IDiagnosisRepository
    {
        Task<IQueryable<DiagnosisViewModel>> GetDiagnosis();
        Task<DiagnosisViewModel> GetDiagnosisById(string id);
        Task CreateDiagnosisAsync(DiagnosisViewModel model);
        Task UpdateDiagnosisAsync(DiagnosisViewModel model);
    }
}
