using MudahMed.Data.ViewModel.CorpGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services.Abstract
{
    public interface ICorpGroupService
    {
        Task<IQueryable<CorpGroupViewModel>> GetAllCorpGroups();
        Task<CorpGroupViewModel> GetCorpGroupByIdAsync(int id);
        Task CreateCorpGroupAsync(CorpGroupViewModel model);
        Task UpdateCorpGroupAsync(CorpGroupViewModel model);
    }

}
