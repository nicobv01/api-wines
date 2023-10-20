using API.Models;
using API.Repositories;

namespace API.Services
{
    public class WineService : IWineService
    {
        private readonly WineRepository _wineRepository;

        public WineService(WineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public Task<Wine> Insert(Wine wine)
        {
            return _wineRepository.Insert(wine);
        }
    }
}
