using Microsoft.EntityFrameworkCore;

namespace Test.Models
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryDetail> InventoryDetails { get; set; }
    }
}