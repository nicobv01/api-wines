using Microsoft.EntityFrameworkCore;

namespace Wine.API.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Wine> Wines { get; set; }
        
    }
}
