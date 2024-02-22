using AgendaProVoluntarios.Data.Entities;
using AgendaProVoluntarios.Data.Persistence;
using AgendaProVoluntarios.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaProVoluntarios.UnitTestes.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task AddAsync_AddsUserToDatabase()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var user = new User("John Doe", "john@example.com", new DateTime(1975,06,19), "hashed_password", 3);

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new UserRepository(dbContext);

                // Act
                await repository.AddAsync(user);
            }

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                // Assert
                var result = await dbContext.User.FirstOrDefaultAsync(u => u.Id == user.Id);
                Assert.NotNull(result);
                Assert.Equal(user.FullName, result.FullName);
                Assert.Equal(user.Email, result.Email);
                Assert.Equal(user.Password, result.Password);
            }
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsWithoutUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User ("John Doe", "john@example.com", new DateTime(1999, 11, 02), "hashed_password", 2 );

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.User.Add(user);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new UserRepository(dbContext);

                // Act
                var result = await repository.GetByIdAsync(userId);

                // Assert
                Assert.Null(result);
            }
        }

        [Fact]
        public async Task GetUserByEmailAndPasswordAsync_ReturnsUser()
        {
            // Arrange
            var userEmail = "john@example.com";
            var passwordHash = "hashed_password";
            var user = new User("John Doe", userEmail, new DateTime(1999, 11, 02), passwordHash, 2);

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.User.Add(user);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new UserRepository(dbContext);

                // Act
                var result = await repository.GetUserByEmailAndPasswordAsync(userEmail, passwordHash);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(userEmail, result.Email);
                Assert.Equal(passwordHash, result.Password);
            }
        }
    }
}
