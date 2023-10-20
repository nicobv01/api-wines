using API.Models;

namespace API.Services
{
    public interface IWineService
    {
        Task<Wine> Insert(Wine wine);
    }
}
