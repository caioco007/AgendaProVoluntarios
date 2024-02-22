using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.DTO.ViewModels
{
    public class FunctionViewModel
    {
        public FunctionViewModel(int typeId, int activityId)
        {
            TypeId = typeId;
            ActivityId = activityId;
        }

        public int TypeId { get; private set; }
        public int ActivityId { get; private set; }
    }
}
