using AgendaProVoluntarios.Data.Entities;
using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetByIdAsync(Guid id);
        Task AddAsync(NewUserInputModel user);
        Task<LoginUserViewModel> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
