using AgendaProVoluntarios.Data.Entities;
using AgendaProVoluntarios.Data.Persistence;
using AgendaProVoluntarios.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Repositories.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MusicRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Music>> GetAllAsync() => await _dbContext.Music.ToListAsync();
        public async Task<Music> GetByIdAsync(Guid id) => await _dbContext.Music.SingleOrDefaultAsync(p => p.Id == id);
        public async Task AddAsync(Music music)
        {
            await _dbContext.Music.AddAsync(music);
            await _dbContext.SaveChangesAsync();
        }
    }
}
