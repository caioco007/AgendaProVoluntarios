using AgendaProVoluntarios.Data.Entities;
using AgendaProVoluntarios.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Services.Interfaces
{
    public interface IFunctionService
    {
        Task<List<FunctionViewModel>> GetAllAsync();
    }
}
