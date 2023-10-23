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
    }
}
