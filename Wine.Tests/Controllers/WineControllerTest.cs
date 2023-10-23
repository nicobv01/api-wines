using API.Controllers;
using API.Models;
using API.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tests.MockData;

namespace Tests.Controllers
{
    public class WineControllerTest
    {
        [Fact]
        public async Task GetAll_ShouldReturn200Status()
        {
            //Arrange
            var mockRepo = new Mock<IWineRepository>();
            mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(WineMockData.GetWines());
            var controller = new WinesController(mockRepo.Object);

            //Act
            var result = await controller.Get();

            //Assert
            result.Should().BeOfType<ActionResult<IEnumerable<Wine>>>();
            result.As<ActionResult<IEnumerable<Wine>>>().Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be(200);
        }
    }
}
