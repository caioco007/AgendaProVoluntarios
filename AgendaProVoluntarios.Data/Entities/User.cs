using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Data.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, string password, int roleId)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true;
            Password = password;
            RoleId = roleId;

            CreatedAt = DateTime.Now;
            Events = new List<UserEvent>();
            Functions = new List<UserFunction>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
        public string Password { get; private set; }
        public int RoleId { get; private set; }

        public List<UserEvent> Events { get; private set; }
        public List<UserFunction> Functions { get; private set; }
    }
}
