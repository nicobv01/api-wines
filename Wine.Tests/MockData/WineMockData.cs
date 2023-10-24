using API.Models;

namespace Tests.MockData
{
    public class WineMockData
    {
        public static List<Wine> GetWines()
        {
            return new List<Wine>
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
        }

        public static Wine AddWine()
        {
            return new Wine
            {
                Id = 4,
                Name = "Wine 4",
                Description = "Description 4",
                CountryCode = "US",
                Type = 2,
                Year = DateTime.Now
            };
        }

        public static Wine GetWine()
        {
            return new Wine
            {
                Id = 5,
                Name = "Wine 5",
                Description = "Description 5",
                CountryCode = "US",
                Type = 2,
                Year = DateTime.Now
            };
        }
    }
}
