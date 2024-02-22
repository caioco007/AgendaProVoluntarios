using AgendaProVoluntarios.Data.Entities;
using AgendaProVoluntarios.Data.Persistence;
using AgendaProVoluntarios.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AgendaProVoluntarios.UnitTestes.Repositories
{
    public class EventRepositoryTests
    {
        [Fact]
        public async Task AddAsync_AddsNewEventToDatabaseAsync()
        {
            // Arrange
            var newEvent = new Event(new DateTime(2024, 02, 18));

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new EventRepository(dbContext);

                // Act
                await repository.AddAsync(newEvent);
            }

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                // Assert
                var result = await dbContext.Event.FindAsync(newEvent.Id);
                Assert.NotNull(result);
                Assert.Equal(newEvent.EventAt, result.EventAt);
            }
        }

        [Fact]
        public async Task GetAll_ReturnsAllEventsAsync()
        {
            // Arrange
            var events = new List<Event>
            {
                new Event(new DateTime(2024, 02, 18)),
                new Event(new DateTime(2024, 02, 25))
            };

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                await dbContext.AddRangeAsync(events);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new EventRepository(dbContext);

                // Act
                var result = await repository.GetAllAsync();

                // Assert
                Assert.Equal(events.Count, result.Count);
                foreach (var ev in events)
                {
                    Assert.Contains(result, e => e.Id == ev.Id && e.EventAt == ev.EventAt);
                }
            }
        }

        [Fact]
        public async Task GetById_ReturnsEventIdWithNullAsync()
        {
            // Arrange
            var eventId = Guid.NewGuid();
            var events = new List<Event>
            {
                new Event(new DateTime(2024, 02, 22)),
                new Event(new DateTime(2024, 02, 29))
            };

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                await dbContext.AddRangeAsync(events);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new EventRepository(dbContext);

                // Act
                var result = await repository.GetByIdAsync(eventId);

                // Assert
                Assert.Null(result);
            }
        }
    }
}
