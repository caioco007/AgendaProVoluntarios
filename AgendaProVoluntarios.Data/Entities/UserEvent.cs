using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Data.Entities
{
    public class UserEvent : BaseEntity
    {
        public UserEvent(Guid userId, Guid eventId)
        {
            UserId = userId;
            EventId = eventId;
            IsConfirmedUser = false;
        }

        public void ConfirmedUser()
        {
            IsConfirmedUser = true;
        }

        public Guid UserId { get; private set; }
        public Guid EventId { get; private set; }
        public bool IsConfirmedUser { get; set; }
    }
}
