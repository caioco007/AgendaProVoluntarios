using AgendaProVoluntarios.Data.Entities;
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
    public class FunctionServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsAllFunctions()
        {
            // Arrange
            var mockRepository = new Mock<IFunctionRepository>();
            var functions = new List<Function>
            {
                new Function(1, 1),
                new Function(2, 2),
                new Function(3, 3)
            };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(functions);

            var functionService = new FunctionService(mockRepository.Object);

            // Act
            var result = await functionService.GetAllAsync();

            // Assert
            Assert.Equal(functions.Count, result.Count);
            // Aqui você pode adicionar mais asserções conforme necessário
        }
    }
}
