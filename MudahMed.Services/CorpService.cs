using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.Corporate;
using MudahMed.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services
{
    public class CorpService : ICorpService
    {
        private readonly ICorpRepository _corpRepository;

        public CorpService(ICorpRepository corpRepository)
        {
            _corpRepository = corpRepository;
        }

        public async Task<IQueryable<CorpViewModel>> GetAllCorps()
        {
            return await _corpRepository.GetCorps();
        }

        public async Task<CorpViewModel> GetCorpByIdAsync(int id)
        {
            return await _corpRepository.GetCorpById(id);
        }

        public async Task CreateCorpAsync(CorpViewModel model)
        {
            await _corpRepository.CreateCorpAsync(model);
        }

        public async Task UpdateCorpAsync(CorpViewModel model)
        {
            await _corpRepository.UpdateCorpAsync(model);
        }
    }

}
