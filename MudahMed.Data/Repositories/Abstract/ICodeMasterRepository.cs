using MudahMed.Data.ViewModel.Clinic;
using MudahMed.Data.ViewModel.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories.Abstract
{
    public interface ICodeMasterRepository
    {
        Task<IQueryable<CodeMasterViewModel>> GetCodeMasters();
        Task<IQueryable<CodeMasterViewModel>> GetCodeMastersByType(string codeType);
        Task<CodeMasterViewModel> GetCodeMasterById(int id);
        Task CreateCodeMasterAsync(CodeMasterViewModel model);
        Task UpdateCodeMasterAsync(CodeMasterViewModel model);
    }
}
