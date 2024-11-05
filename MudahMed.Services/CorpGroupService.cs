using MudahMed.Data.Repositories.Abstract;
using MudahMed.Data.ViewModel.CorpGroup;
using MudahMed.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services
{
    public class CorpGroupService : ICorpGroupService
    {
        private readonly ICorpGroupRepository _corpGroupRepository;

        public CorpGroupService(ICorpGroupRepository corpGroupRepository)
        {
            _corpGroupRepository = corpGroupRepository;
        }

        public async Task<IQueryable<CorpGroupViewModel>> GetAllCorpGroups()
        {
            return await _corpGroupRepository.GetCorpGroups();
        }

        public async Task<CorpGroupViewModel> GetCorpGroupByIdAsync(int id)
        {
            return await _corpGroupRepository.GetCorpGroupById(id);
        }

        public async Task CreateCorpGroupAsync(CorpGroupViewModel model)
        {
            await _corpGroupRepository.CreateCorpGroupAsync(model);
        }

        public async Task UpdateCorpGroupAsync(CorpGroupViewModel model)
        {
            await _corpGroupRepository.UpdateCorpGroupAsync(model);
        }
    }

}
