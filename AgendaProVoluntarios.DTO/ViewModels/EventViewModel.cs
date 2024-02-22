using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.DTO.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel(DateTime eventAt)
        {
            EventAt = eventAt;
        }
        public DateTime EventAt { get; private set; }
    }
}
