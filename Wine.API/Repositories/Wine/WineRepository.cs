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

        public async Task<bool> Insert(Wine wine)
        {
            try
            {
                _context.Wines.Add(wine);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<Wine?> GetById(int id)
        {
            return await _context.Wines.FindAsync(id);
        }

        public async Task<bool> Update(Wine wine)
        {
            var existingWine = await _context.Wines.FindAsync(wine.Id);
            if (existingWine == null)
            {
                return false;
            }

            existingWine.Id = wine.Id;
            existingWine.Name = existingWine.Name;
            existingWine.Description = existingWine.Description;
            existingWine.CountryCode = wine.CountryCode;
            existingWine.Type = wine.Type;
            existingWine.Year = wine.Year;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(int id)
        {
            var wine = await _context.Wines.FindAsync(id);
            if (wine == null)
            {
                return false;
            }

            _context.Wines.Remove(wine);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
