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

        public async Task<IEnumerable<Wine>> GetAll()
        {
            return await _context.Wines.ToListAsync();            
        }

        public async Task<Wine> Insert(Wine wine)
        {
            _context.Wines.Add(wine);
            await _context.SaveChangesAsync();
            return wine;
        }
    }
}
