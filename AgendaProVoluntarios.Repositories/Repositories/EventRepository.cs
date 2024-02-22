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
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Event>> GetAllAsync() => await _dbContext.Event.ToListAsync();
        public async Task<Event> GetByIdAsync(Guid id) => await _dbContext.Event.SingleOrDefaultAsync(p => p.Id == id);
        public async Task AddAsync(Event events)
        {
            await _dbContext.Event.AddAsync(events);
            await _dbContext.SaveChangesAsync();
        }
    }
}
