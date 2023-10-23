using API.Controllers;
using API.Models;
using API.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Tests.MockData;

namespace Tests.Controllers
{
    public class WineControllerTest
    {
        [Fact]
        public async Task GetAll_ShouldReturn200Status()
        {
            //Arrange
            var mockRepo = Substitute.For<IWineRepository>();
            mockRepo.GetAll().Returns(WineMockData.GetWines());
            var controller = new WinesController(mockRepo);

            //Act
            var result = await controller.Get();

            //Assert
            result.Should().BeOfType<ActionResult<IEnumerable<Wine>>>();
            result.As<ActionResult<IEnumerable<Wine>>>().Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task Insert_ShouldCallWineSaveAsyncOnce()
        {
            //Arrange
            var mockRepo = Substitute.For<IWineRepository>();
            var newWine = WineMockData.AddWine();
            var controller = new WinesController(mockRepo);
            mockRepo.Insert(Arg.Any<Wine>()).Returns(true);

            //Act
            var result = await controller.Post(newWine);

            //Assert    
            result.Should().BeOfType<ActionResult<Wine>>();
            result.As<ActionResult<Wine>>().Result.Should().BeOfType<CreatedAtActionResult>()
               .Which.StatusCode.Should().Be(201);
        }
    }
}
