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
    public class FunctionRepositoryTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllFunctionsAsync()
        {
            // Arrange
            var functions = new List<Function>
            {
                new Function(1,2),
                new Function(2,1)
            };

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                await dbContext.AddRangeAsync(functions);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var repository = new FunctionRepository(dbContext);

                // Act
                var result = await repository.GetAllAsync();

                // Assert
                Assert.Equal(functions.Count, result.Count);
                foreach (var fun in functions)
                {
                    Assert.Contains(result, f => f.Id == fun.Id && f.TypeId == fun.TypeId && f.ActivityId == fun.ActivityId);
                }
            }
        }

    }
}
