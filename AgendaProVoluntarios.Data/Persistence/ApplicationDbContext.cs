using AgendaProVoluntarios.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Data.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserEvent> UserEvent { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventMusic> EventMusic { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Function> Function { get; set; }
        public DbSet<UserFunction> UserFunction { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
