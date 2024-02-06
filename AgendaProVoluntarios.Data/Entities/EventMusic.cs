using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Data.Entities
{
    public class EventMusic : BaseEntity
    {
        public EventMusic()
        {

        }
        public Guid EventId { get; private set; }
        public Guid MusicId { get; private set; }
    }
}
