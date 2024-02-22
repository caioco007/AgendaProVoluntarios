using AgendaProVoluntarios.DTO.InputModels;
using AgendaProVoluntarios.DTO.ViewModels;

namespace AgendaProVoluntarios.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<EventViewModel>> GetAllAsync();
        Task<EventViewModel> GetByIdAsync(Guid id);
        Task AddAsync(NewEventInputModel inputModel);
    }
}
