using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.General;
using MudahMed.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services
{
    public class CodeMasterService : ICodeMasterService
    {
        private readonly ICodeMasterRepository _CodeMasterRepository;

        public CodeMasterService(ICodeMasterRepository CodeMasterRepository)
        {
            _CodeMasterRepository = CodeMasterRepository;
        }

        public async Task<IQueryable<CodeMasterViewModel>> GetAllCodeMasters()
        {
            return await _CodeMasterRepository.GetCodeMasters();
        }
        public async Task<IQueryable<CodeMasterViewModel>> GetAllCodeMastersByCodeType(string codeType)
        {
            return await _CodeMasterRepository.GetCodeMastersByType(codeType);
        }

        public async Task<CodeMasterViewModel> GetCodeMasterByIdAsync(int id)
        {
            return await _CodeMasterRepository.GetCodeMasterById(id);
        }

        public async Task CreateCodeMasterAsync(CodeMasterViewModel model)
        {
            await _CodeMasterRepository.CreateCodeMasterAsync(model);
        }

        public async Task UpdateCodeMasterAsync(CodeMasterViewModel model)
        {
            await _CodeMasterRepository.UpdateCodeMasterAsync(model);
        }

    }
}
