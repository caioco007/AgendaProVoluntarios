using AgendaProVoluntarios.Data.Entities;
using AgendaProVoluntarios.DTO.InputModels;
using AgendaProVoluntarios.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.Services.Interfaces
{
    public interface IMusicService
    {
        Task<List<MusicViewModel>> GetAllAsync();
        Task<MusicViewModel> GetByIdAsync(Guid id);
        Task AddAsync(NewMusicInputModel inputModel);
    }
}
