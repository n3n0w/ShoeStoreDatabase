using Moq;
using ShoeStore.Services;
using ShoeStore.Core.Models;
using ShoeStore.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ShoeStore.Tests
{
    public class BusinessServiceTests
    {
        [Fact]
        public async Task GetTotalShoesAsync_ShouldReturnCorrectCount()
        {
            // Arrange
            var mockShoeRepository = new Mock<ShoeRepository>(MockBehavior.Strict, null);
            mockShoeRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Shoe> { new Shoe(), new Shoe() });

            var shoeService = new ShoeService(mockShoeRepository.Object);
            var businessService = new BusinessService(shoeService, customerService: null);

            // Act
            var result = await businessService.GetTotalShoesAsync();

            // Assert
            Assert.Equal(2, result);
        }
    }
}