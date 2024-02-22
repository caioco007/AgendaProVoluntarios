using AgendaProVoluntarios.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Repositories.Interfaces
{
    public interface IFunctionRepository
    {
        Task<List<Function>> GetAllAsync();
    }
}
