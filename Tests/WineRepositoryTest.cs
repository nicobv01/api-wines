using API.Data;
using API.Models;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests
{
    public class WineRepositoryTest
    {
        [Fact]
        public async Task InsertWine_CheckInsertedData_Success()
        {
            int id = 123;
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Wine")
                .Options;

            var result = new Wine();

            using (var context = new AppDbContext(options))
            {
                var wineRepository = new WineRepository(context);
                var wine = new Wine
                {
                    Id = id,
                    Name = "Test Wine",
                    Description = "Test Wine",
                    CountryCode = "RD",
                    Type = 1
                };
                result = await wineRepository.Insert(wine);
            }

            Assert.Equal(id, result.Id);

        }
    }
}