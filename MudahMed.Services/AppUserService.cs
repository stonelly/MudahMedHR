using MudahMed.Data.Entities;
using MudahMed.Data.Repositories.Abstract;
using MudahMed.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _userRepository;

        public AppUserService(IAppUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IList<AppUser>> GetAllUsers()
        {
            return await Task.Run(() => _userRepository.GetAll()); 
        }
    }
}
