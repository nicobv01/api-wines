using API.Data;
using API.Models;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests
{
    public class WineRepositoryTest
    {
        private readonly AppDbContext _context;
        private readonly IWineRepository _wineRepository;

        public WineRepositoryTest()
        {    var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "Wine")
            .Options;
        
            _context = new AppDbContext(options);

            AddInitialWines();

            _wineRepository = new WineRepository(_context);
        }

        public void AddInitialWines()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var initialWines = new List<Wine>
            {
                new Wine
                {
                    Id = 1,
                    Name = "Wine 1",
                    Description = "Description 1",
                    CountryCode = "RD",
                    Type = 1,
                    Year = DateTime.Now
                },
                new Wine
                {
                    Id = 2,
                    Name = "Wine 2",
                    Description = "Description 2",
                    CountryCode = "US",
                    Type = 2,
                    Year = DateTime.Now
                },
                new Wine
                {
                    Id = 3,
                    Name = "Wine 3",
                    Description = "Description 3",
                    CountryCode = "US",
                    Type = 2,
                    Year = DateTime.Now
                }
            };

            _context.Wines.AddRange(initialWines);
            _context.SaveChanges();
        }


        [Fact]
        public async Task Insert_ValidWine_ShouldSucceed()
        {
            //Arrange
            int id = 4;
            var wine = new Wine
            {
                Id = id,
                Name = "Test Wine",
                Description = "Test Wine",
                CountryCode = "RD",
                Type = 1
            };

            //Act
            var result = await _wineRepository.Insert(wine);
     
            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllWines_ShouldReturnNonEmptyList()
        {
            //Act
            var result = await _wineRepository.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetById_ValidId_ShouldReturnMatchingWine()
        {
            //Arrange
            int id = 1;

            //Act
            var result = await _wineRepository.GetById(id);

            //Assert
            Assert.Equal(id, result?.Id);
        }

        [Fact]
        public async Task UpdateWine_WithValidId_ShouldReturnTrue()
        {
            //Arrange
             int id = 2;
             var wine = new Wine
             {
                 Id = id,
                 Name = "Test Wine Updated",
                 Description = "Test Wine",
                 CountryCode = "RD",
                 Type = 2,
                 Year = DateTime.Now
             };

            //Act
            var updatedWine = await _wineRepository.Update(wine);

            //Assert
            Assert.True(updatedWine);
        }

        [Fact]
        public async Task DeleteWine_WithValidId_ShouldReturnTrue()
        {
            //Arrange
            int id = 3;

            //Act
            var result = await _wineRepository.DeleteById(id);

            //Assert
            Assert.True(result);
        }

    }
}