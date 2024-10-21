using MudahMed.Data.ViewModel.Corporate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories.Abstract
{
    public interface ICorpUserRepository
    {
        Task<List<CorpUserViewModel>> GetCorpUsersAsync();
        Task<CorpUserViewModel> GetCorpUserByIdAsync(Guid userId);
        Task CreateCorpUserAsync(CorpUserViewModel model);
        Task UpdateCorpUserAsync(CorpUserViewModel model);
    }
}
