using MudahMed.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Services.Abstract
{
    public interface IAppUserService
    {
        Task<IList<AppUser>> GetAllUsers();

        Task<IList<AppUser>> GetUsersByRoleAsync(string roleName);
    }
}
