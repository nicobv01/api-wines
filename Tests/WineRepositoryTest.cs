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
{             var options = new DbContextOptionsBuilder<AppDbContext>()
                        .UseInMemoryDatabase(databaseName: "Wine")
                                        .Options;
        
            _context = new AppDbContext(options);
            _wineRepository = new WineRepository(_context);
        }

        [Fact]
        public async Task InsertWine_CheckInsertedData_Success()
        {
            int id = 22;
    
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

    }
}