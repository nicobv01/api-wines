using API.Models;
using API.Repositories;

namespace API.Services
{
    public class WineService : IWineRepository
    {
        private readonly IWineRepository _wineRepository;

        public WineService(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public Task<Wine> Insert(Wine wine)
        {
            return _wineRepository.Insert(wine);
        }
    }
}
