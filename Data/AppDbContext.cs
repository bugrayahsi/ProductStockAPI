using Microsoft.EntityFrameworkCore;
using ProductStockAPI.Models;

namespace ProductStockAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

    }
}
