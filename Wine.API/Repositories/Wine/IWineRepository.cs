using API.Models;

namespace API.Repositories
{
    public interface IWineRepository
    {
        Task<IEnumerable<Wine>> GetAll();
        Task<Wine?> GetById(int id);
        Task<bool> Insert(Wine wine);
        Task<bool> Update(Wine wine);
        Task<bool> DeleteById(int id);
    }
}
