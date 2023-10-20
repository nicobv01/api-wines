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

        public async Task<Wine?> GetById(int id)
        {
            return await _context.Wines.FindAsync(id);
        }

        public async Task<Wine?> Update(Wine wine)
        {
            var entityEntry = _context.Wines.Update(wine);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<Wine?> DeleteById(int id)
        {
            var wine = await _context.Wines.FindAsync(id);
            if (wine == null)
            {
                return null;
            }

            _context.Wines.Remove(wine);
            await _context.SaveChangesAsync();
            return wine;
        }
    }
}
