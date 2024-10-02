using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudahMed.Data.DataContext
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
