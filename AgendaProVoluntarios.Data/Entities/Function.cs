using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Data.Entities
{
    public class Function : BaseEntity
    {
        public Function(int typeId, int activityId)
        {
            TypeId = typeId;
            ActivityId = activityId;
        }

        public int TypeId { get; private set; }
        public int ActivityId { get; private set; }
    }
}
