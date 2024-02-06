using AgendaProVoluntarios.Data.Persistence;
using AgendaProVoluntarios.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Repositories.Repositories
{
    public class FunctionRepository : IFunctionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FunctionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
