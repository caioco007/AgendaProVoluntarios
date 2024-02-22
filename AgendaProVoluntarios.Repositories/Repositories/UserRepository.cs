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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(Guid id) => await _dbContext.User.SingleOrDefaultAsync(u => u.Id == id);

        public async Task AddAsync(User user)
        {
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash) => await _dbContext.User.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);

    }
}
