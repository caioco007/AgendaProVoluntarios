using AgendaProVoluntarios.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Repositories.Interfaces
{
    public interface IMusicRepository
    {
        Task<List<Music>> GetAllAsync();
        Task<Music> GetByIdAsync(Guid id);
        Task AddAsync(Music music);
    }
}
