using MudahMed.Data.ViewModel.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services.Abstract
{
    public interface ICodeMasterService
    {
        Task<IQueryable<CodeMasterViewModel>> GetAllCodeMasters();
        Task<IQueryable<CodeMasterViewModel>> GetAllCodeMastersByCodeType(string codeType);
        Task<CodeMasterViewModel> GetCodeMasterByIdAsync(int id);
        Task CreateCodeMasterAsync(CodeMasterViewModel model);
        Task UpdateCodeMasterAsync(CodeMasterViewModel model);
    }
}
