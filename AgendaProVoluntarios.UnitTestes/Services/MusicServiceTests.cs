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
    public class MusicServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsAllMusics()
        {
            // Arrange
            var mockRepository = new Mock<IMusicRepository>();
            var musics = new List<Music>
            {
                new Music("Music 1", "Key 1"),
                new Music("Music 2", "Key 2"),
                new Music("Music 3", "Key 3")
            };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(musics);

            var musicService = new MusicService(mockRepository.Object);

            // Act
            var result = await musicService.GetAllAsync();

            // Assert
            Assert.Equal(musics.Count, result.Count);
            // Aqui você pode adicionar mais asserções conforme necessário
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsMusic()
        {
            // Arrange
            var mockRepository = new Mock<IMusicRepository>();
            var musicId = Guid.NewGuid();
            var music = new Music("Test Music", "Test Key");
            mockRepository.Setup(repo => repo.GetByIdAsync(musicId)).ReturnsAsync(music);

            var musicService = new MusicService(mockRepository.Object);

            // Act
            var result = await musicService.GetByIdAsync(musicId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(music.Name, result.Name);
            Assert.Equal(music.Key, result.Key);
            // Outras asserções podem ser adicionadas conforme necessário
        }

        [Fact]
        public async Task AddAsync_AddsNewMusic()
        {
            // Arrange
            var mockRepository = new Mock<IMusicRepository>();
            var inputModel = new NewMusicInputModel { Name = "New Music", Key = "New Key" };

            var musicService = new MusicService(mockRepository.Object);

            // Act
            await musicService.AddAsync(inputModel);

            // Assert
            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Music>()), Times.Once);
            // Aqui você pode adicionar mais asserções conforme necessário
        }
    }
}
