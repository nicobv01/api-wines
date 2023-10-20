using API.Models;

namespace API.Repositories
{
    public interface IWineRepository
    {
        Task<IEnumerable<Wine>> GetAll();
        Task<Wine> Insert(Wine wine);
    }
}
