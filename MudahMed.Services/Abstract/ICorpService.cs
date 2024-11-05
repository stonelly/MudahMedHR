using MudahMed.Data.ViewModel.Corporate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services.Abstract
{
    public interface ICorpService
    {
        Task<IQueryable<CorpViewModel>> GetAllCorps();
        Task<CorpViewModel> GetCorpByIdAsync(int id);
        Task CreateCorpAsync(CorpViewModel model);
        Task UpdateCorpAsync(CorpViewModel model);
    }

}
