using API.Models;

namespace API.Repositories
{
    public interface IWineRepository
    {
        Task<IEnumerable<Wine>> GetAll();
        Task<Wine?> GetById(int id);
        Task<Wine> Insert(Wine wine);
        Task<Wine?> Update(Wine wine);
    }
}
