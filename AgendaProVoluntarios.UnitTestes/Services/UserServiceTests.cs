using AgendaProVoluntarios.Data.Entities;
using AgendaProVoluntarios.Repositories.Interfaces;
using AgendaProVoluntarios.Services.Auth;
using AgendaProVoluntarios.Services.Services;
using DevFreela.Application.InputModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.UnitTestes.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetByIdAsync_ReturnsUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var mockRepository = new Mock<IUserRepository>();
            var mockAuthService = new Mock<IAuthService>();
            var user = new User("John Doe", "john@example.com", new DateTime(2001,10,11), "1234567890", 1);
            mockRepository.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);

            var userService = new UserService(mockRepository.Object, mockAuthService.Object);

            // Act
            var result = await userService.GetByIdAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.FullName, result.FullName);
            Assert.Equal(user.Email, result.Email);
            // Adicione outras asserções conforme necessário
        }

        [Fact]
        public async Task AddAsync_AddsNewUser()
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var mockAuthService = new Mock<IAuthService>();
            var inputModel = new NewUserInputModel
            {
                FullName = "Jane Doe",
                Password = "password123",
                Email = "jane@example.com",
                RoleId = 1,
                BirthDate = DateTime.Parse("1990-01-01")
            };

            var userService = new UserService(mockRepository.Object, mockAuthService.Object);

            // Act
            await userService.AddAsync(inputModel);

            // Assert
            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<User>()), Times.Once);
            // Adicione outras asserções conforme necessário
        }

        [Fact]
        public async Task GetUserByEmailAndPasswordAsync_ReturnsNull()
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var mockAuthService = new Mock<IAuthService>();
            var email = "john@example.com";
            var passwordHash = "hashed_password";
            var user = new User("John Doe", email, new DateTime(2001, 10, 11), "hashed_password", 1);
            mockRepository.Setup(repo => repo.GetUserByEmailAndPasswordAsync(email, passwordHash)).ReturnsAsync(user);

            var userService = new UserService(mockRepository.Object, mockAuthService.Object);

            // Act
            var result = await userService.GetUserByEmailAndPasswordAsync(email, passwordHash);

            // Assert
            Assert.Null(result);
            // Adicione outras asserções conforme necessário
        }
    }
}
