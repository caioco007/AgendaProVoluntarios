using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Data.Entities
{
    public class Role : BaseEntity
    {
        public Role(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
