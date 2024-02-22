using AgendaProVoluntarios.Data.Entities;
using AgendaProVoluntarios.Data.Persistence;
using AgendaProVoluntarios.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.UnitTestes.Repositories
{
    public class MusicRepositoryTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllMusics()
        {
            // Arrange
            var musics = new List<Music>
            {
                new Music("Song 1", "C#"),
                new Music("Song 2", "D"),
                new Music("Song 3", "G")
            };

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                await dbContext.AddRangeAsync(musics);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new MusicRepository(dbContext);

                // Act
                var result = await repository.GetAllAsync();

                // Assert
                Assert.Equal(musics.Count, result.Count);
                foreach (var music in musics)
                {
                    Assert.Contains(result, m => m.Id == music.Id && m.Name == music.Name && m.Key == music.Key);
                }
            }
        }

        [Fact]
        public async Task GetById_ReturnsMusicWithNullAsync()
        {
            // Arrange
            var musicId = Guid.NewGuid();
            var expectedMusic = new Music("Song", "C#");

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                await dbContext.AddRangeAsync(expectedMusic);
                await dbContext.SaveChangesAsync();
            }
            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new MusicRepository(dbContext);

                // Act
                var result = await repository.GetByIdAsync(musicId);

                // Assert
                Assert.Null(result);
            }
        }

        [Fact]
        public async Task AddAsync_AddsNewMusicToDatabase()
        {
            // Arrange
            var newMusic = new Music("New Song", "A#");

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new MusicRepository(dbContext);

                // Act
                await repository.AddAsync(newMusic);
            }

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                // Assert
                var result = await dbContext.Music.FindAsync(newMusic.Id);
                Assert.NotNull(result);
                Assert.Equal(newMusic.Name, result.Name);
                Assert.Equal(newMusic.Key, result.Key);
            }
        }
    }
}
