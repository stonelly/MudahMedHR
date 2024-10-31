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
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IDiagnosisRepository _diagnosisRepository;

        public DiagnosisService(IDiagnosisRepository diagnosisRepository)
        {
            _diagnosisRepository = diagnosisRepository;
        }

        public async Task<IQueryable<DiagnosisViewModel>> GetAllDiagnosis()
        {
            return await _diagnosisRepository.GetDiagnosis();
        }

        public async Task<DiagnosisViewModel> GetDiagnosisByIdAsync(string id)
        {
            return await _diagnosisRepository.GetDiagnosisById(id);
        }

        public async Task CreateDiagnosisAsync(DiagnosisViewModel model)
        {
            await _diagnosisRepository.CreateDiagnosisAsync(model);
        }

        public async Task UpdateDiagnosisAsync(DiagnosisViewModel model)
        {
            await _diagnosisRepository.UpdateDiagnosisAsync(model);
        }

    }
}
