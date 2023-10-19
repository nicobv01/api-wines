using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class WineRepository : IWineRepository
    {
        private readonly AppDbContext _context;

        public WineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Wine> Insert(Wine wine)
        {
            _context.Wines.Add(wine);
            await _context.SaveChangesAsync();
            return wine;
        }
    }
}
