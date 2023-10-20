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
            _wineRepository = new WineRepository(_context);
        }

        [Fact]
        public async Task When_InsertWine()
        {
            int id = 1;
    
            var wine = new Wine
            {
                Id = id,
                Name = "Test Wine",
                Description = "Test Wine",
                CountryCode = "RD",
                Type = 1
            };
            var result = await _wineRepository.Insert(wine);
     
            Assert.Equal(id, result.Id);

        }

        [Fact]
        public async Task When_GetAllWines()
        {
            var result = await _wineRepository.GetAll();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task When_GetWineById()
        {
            int id = 2;
            var wine = new Wine
            {
                Id = id,
                Name = "Test Wine",
                Description = "Test Wine",
                CountryCode = "RD",
                Type = 1
            };
            await _wineRepository.Insert(wine);

            var result = await _wineRepository.GetById(id);

            Assert.Equal(id, result?.Id);
        }

        [Fact]
        public async Task When_UpdateWine()
        {
            int id = 3;
            var wine = new Wine
            {
                Id = id,
                Name = "Test Wine",
                Description = "Test Wine",
                CountryCode = "RD",
                Type = 1
            };
            var result = await _wineRepository.Insert(wine);

            result.Name = "Test Wine Updated";
            var updatedWine = await _wineRepository.Update(result);

            Assert.Equal("Test Wine Updated", updatedWine?.Name);
        }

        [Fact]
        public async Task When_DeleteWine()
        {
            int id = 4;
            var wine = new Wine
            {
                Id = id,
                Name = "Test Wine",
                Description = "Test Wine",
                CountryCode = "RD",
                Type = 1
            };
            await _wineRepository.Insert(wine);

            await _wineRepository.DeleteById(id);

            var result = await _wineRepository.GetById(id);

            Assert.Null(result);
        }

    }
}