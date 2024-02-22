using AgendaProVoluntarios.Data.Entities;
using AgendaProVoluntarios.DTO.InputModels;
using AgendaProVoluntarios.DTO.ViewModels;
using AgendaProVoluntarios.Repositories.Interfaces;
using AgendaProVoluntarios.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaProVoluntarios.Services.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<EventViewModel>> GetAllAsync()
        {
            var events = await _eventRepository.GetAllAsync();

            return events.Select(e => new EventViewModel(e.EventAt)).ToList();
        }
        public async Task<EventViewModel> GetByIdAsync(Guid id)
        {
            var events = await _eventRepository.GetByIdAsync(id);
            if (events == null)
            {
                return null;
            }
            return new EventViewModel(events.EventAt);
        }
        public async Task AddAsync(NewEventInputModel inputModel)
        {
            var eventModel = new Event(inputModel.EventAt);

            await _eventRepository.AddAsync(eventModel);
        }
    }
}
