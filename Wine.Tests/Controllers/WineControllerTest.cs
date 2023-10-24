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
            result.As<ActionResult<IEnumerable<Wine>>>().Result.As<OkObjectResult>().Value.Should().BeOfType<List<Wine>>()
                .Which.Count.Should().Be(3);
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

        [Fact]
        public async Task Insert_ShouldReturnBadRequest()
        {
            //Arrange
            var mockRepo = Substitute.For<IWineRepository>();
            var newWine = WineMockData.AddWine();
            var controller = new WinesController(mockRepo);
            mockRepo.Insert(Arg.Any<Wine>()).Returns(false);

            //Act
            var result = await controller.Post(newWine);

            //Assert    
            result.Should().BeOfType<ActionResult<Wine>>();
            result.As<ActionResult<Wine>>().Result.Should().BeOfType<BadRequestResult>()
               .Which.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetById_ShouldReturn200Status()
        {
            //Arrange
            var mockRepo = Substitute.For<IWineRepository>();
            var wine = WineMockData.GetWine();
            var controller = new WinesController(mockRepo);
            mockRepo.GetById(Arg.Any<int>()).Returns(wine);

            //Act
            var result = await controller.GetById(5);

            //Assert
            result.Should().BeOfType<ActionResult<Wine>>();
            result.As<ActionResult<Wine>>().Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be(200);
            result.As<ActionResult<Wine>>().Result.As<OkObjectResult>().Value.Should().BeOfType<Wine>()
                .Which.Id.Should().Be(5);
        }

        [Fact]
        public async Task GetById_ShouldReturn404Status()
        {
            //Arrange
            var mockRepo = Substitute.For<IWineRepository>();
            var controller = new WinesController(mockRepo);
            mockRepo.GetById(Arg.Any<int>()).Returns((Wine?)null);

            //Act
            var result = await controller.GetById(5);

            //Assert
            result.Should().BeOfType<ActionResult<Wine>>();
            result.As<ActionResult<Wine>>().Result.Should().BeOfType<NotFoundResult>()
                .Which.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Update_ShouldReturn200Status()
        {
            //Arrange
            var mockRepo = Substitute.For<IWineRepository>();
            var wine = WineMockData.GetWine();
            var controller = new WinesController(mockRepo);
            mockRepo.Update(Arg.Any<Wine>()).Returns(true);

            //Act
            var result = await controller.Put(5, wine);

            //Assert
            result.Should().BeOfType<ActionResult<Wine>>();
            result.As<ActionResult<Wine>>().Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Update_ShouldReturn404Status()
        {
            //Arrange
            var mockRepo = Substitute.For<IWineRepository>();
            var wine = WineMockData.GetWine();
            var controller = new WinesController(mockRepo);
            mockRepo.Update(Arg.Any<Wine>()).Returns(false);

            //Act
            var result = await controller.Put(5, wine);

            //Assert
            result.Should().BeOfType<ActionResult<Wine>>();
            result.As<ActionResult<Wine>>().Result.Should().BeOfType<NotFoundResult>()
                .Which.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Delete_ShouldReturn200Status()
        {
            //Arrange
            var mockRepo = Substitute.For<IWineRepository>();
            var controller = new WinesController(mockRepo);
            mockRepo.DeleteById(Arg.Any<int>()).Returns(true);

            //Act
            var result = await controller.Delete(5);

            //Assert
            result.Should().BeOfType<OkResult>();
            result.As<OkResult>().StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Delete_ShouldReturn404Status()
        {
            //Arrange
            var mockRepo = Substitute.For<IWineRepository>();
            var controller = new WinesController(mockRepo);
            mockRepo.DeleteById(Arg.Any<int>()).Returns(false);

            //Act
            var result = await controller.Delete(5);

            //Assert
            result.Should().BeOfType<NotFoundResult>();
            result.As<NotFoundResult>().StatusCode.Should().Be(404);
        }

    }
}
