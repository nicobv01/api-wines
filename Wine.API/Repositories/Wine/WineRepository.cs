using API.Models;

namespace API.Repositories
{
    public class WineRepository : IWineRepository
    {
        Task<Wine> IWineRepository.Insert(Wine wine)
        {
            throw new NotImplementedException();
        }
    }
}
