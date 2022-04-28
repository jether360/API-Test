using Microsoft.EntityFrameworkCore;

namespace Test.Models
{
    public class MedicinesDbContext : DbContext
    {
        public MedicinesDbContext(DbContextOptions<MedicinesDbContext> options) : base(options)
        {
        }

        public DbSet<DMedicines> DMedicine { get; set; }
    }
}