using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Data.Entities
{
    public class Event : BaseEntity
    {
        public Event(DateTime eventAt)
        {
            EventAt = eventAt;
            CreatedAt = DateTime.Now;

            Users = new List<UserEvent>();
            Musics = new List<EventMusic>();
        }
        public DateTime EventAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<UserEvent> Users { get; private set; }
        public List<EventMusic> Musics { get; private set; }
    }
}
