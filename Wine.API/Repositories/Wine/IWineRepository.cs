using API.Models;

namespace API.Repositories
{
    public interface IWineRepository
    {
        Task<Wine> Insert(Wine wine);
    }
}
