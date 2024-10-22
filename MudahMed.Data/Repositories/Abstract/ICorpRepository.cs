using MudahMed.Data.ViewModel.Corporate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.Repositories.Abstract
{
    public interface ICorpRepository
    {
        Task<List<CorpViewModel>> GetCorpsAsync();
        Task<CorpViewModel> GetCorpByIdAsync(Guid Id);
        Task CreateCorpAsync(CorpViewModel model);
        Task UpdateCorpAsync(CorpViewModel model);
    }
}
