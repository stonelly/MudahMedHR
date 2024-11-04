using MudahMed.Data.ViewModel.CorpGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories.Abstract
{
    public interface ICorpGroupRepository
    {
        Task<IQueryable<CorpGroupViewModel>> GetCorpGroups();
        Task<CorpGroupViewModel> GetCorpGroupById(int id);
        Task CreateCorpGroupAsync(CorpGroupViewModel model);
        Task UpdateCorpGroupAsync(CorpGroupViewModel model);
    }
}
