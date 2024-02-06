using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Data.Entities
{
    public class UserFunction : BaseEntity
    {
        public UserFunction(Guid userId, Guid functionId)
        {
            UserId = userId;
            FunctionId = functionId;
        }

        public Guid UserId { get; private set; }
        public Guid FunctionId { get; private set; }
    }
}
