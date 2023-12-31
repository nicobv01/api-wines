using API.Data;
using API.Models;
using API.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Tests.Repositories
{
    public class WineRepositoryTest : IDisposable
    {
        private readonly AppDbContext _context;
        private readonly IWineRepository _wineRepository;

        public WineRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "Wine")
            .Options;

            _context = new AppDbContext(options);

            AddInitialWines();

            _wineRepository = new WineRepository(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }

        public void AddInitialWines()
        {
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
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetAllWines_ShouldReturnNonEmptyList()
        {
            //Act
            var result = await _wineRepository.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Should().BeOfType<List<Wine>>();
            result.Should().BeEquivalentTo(_context.Wines.ToList());
        }

        [Fact]
        public async Task GetById_ValidId_ShouldReturnMatchingWine()
        {
            //Arrange
            int id = 1;

            //Act
            var result = await _wineRepository.GetById(id);

            //Assert
            result.Should().BeOfType<Wine>();
            result?.Id.Should().Be(id); 
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
            updatedWine.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteWine_WithValidId_ShouldReturnTrue()
        {
            //Arrange
            int id = 3;

            //Act
            var result = await _wineRepository.DeleteById(id);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteWine_WithInvalidId_ShouldReturnFalse()
        {
            //Arrange
            int id = 5;

            //Act
            var result = await _wineRepository.DeleteById(id);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task GetById_WithInvalidId_ShouldReturnNull()
        {
            //Arrange
            int id = 5;

            //Act
            var result = await _wineRepository.GetById(id);

            //Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task Insert_DuplicateWine_ShouldReturnFalse()
        {
            //Arrange
            var wine = new Wine
            {
                Id = 1,
                Name = "Test Wine",
                Description = "Test Wine",
                CountryCode = "RD",
                Type = 1
            };

            //Act
            var result = await _wineRepository.Insert(wine);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task UpdateWine_WithInvalidId_ShouldReturnFalse()
        {
            //Arrange
            var wine = new Wine
            {
                Name = "Test Wine Updated",
                Description = "Test Wine",
                CountryCode = "RD",
                Type = 2,
                Year = DateTime.Now
            };

            //Act
            var updatedWine = await _wineRepository.Update(wine);

            //Assert
            updatedWine.Should().BeFalse();
        }
    }
}