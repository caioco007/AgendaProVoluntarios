using AgendaProVoluntarios.Data.Entities;
using AgendaProVoluntarios.DTO.InputModels;
using AgendaProVoluntarios.Repositories.Interfaces;
using AgendaProVoluntarios.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.UnitTestes.Services
{
    public class EventServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsAllEvents()
        {
            // Arrange
            var mockRepository = new Mock<IEventRepository>();
            var events = new List<Event>
            {
                new Event(new DateTime(2024, 2, 15)),
                new Event(new DateTime(2024, 2, 16)),
                new Event(new DateTime(2024, 2, 17))
            };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(events);

            var eventService = new EventService(mockRepository.Object);

            // Act
            var result = await eventService.GetAllAsync();

            // Assert
            Assert.Equal(events.Count, result.Count);
            // Aqui você pode adicionar mais asserções conforme necessário
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsEvent()
        {
            // Arrange
            var mockRepository = new Mock<IEventRepository>();
            var eventId = Guid.NewGuid();
            var @event = new Event(new DateTime(2024, 2, 15));
            mockRepository.Setup(repo => repo.GetByIdAsync(eventId)).ReturnsAsync(@event);

            var eventService = new EventService(mockRepository.Object);

            // Act
            var result = await eventService.GetByIdAsync(eventId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(@event.EventAt, result.EventAt);
            // Outras asserções podem ser adicionadas conforme necessário
        }

        [Fact]
        public async Task AddAsync_AddsNewEvent()
        {
            // Arrange
            var mockRepository = new Mock<IEventRepository>();
            var inputModel = new NewEventInputModel { EventAt = new DateTime(2024, 2, 15) };

            var eventService = new EventService(mockRepository.Object);

            // Act
            await eventService.AddAsync(inputModel);

            // Assert
            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Event>()), Times.Once);
            // Aqui você pode adicionar mais asserções conforme necessário
        }
    }
}
