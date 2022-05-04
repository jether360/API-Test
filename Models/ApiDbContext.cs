using Microsoft.EntityFrameworkCore;

namespace Test.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<DMedicines> DMedicine { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryDetail> InventoryDetails { get; set; }
    }
}