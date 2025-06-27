using Microsoft.EntityFrameworkCore;
using POSWebAPI.Models;
using System.Collections.Generic;

namespace POSWebAPI.Data
{
    public class POSDbContext : DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> options) : base(options) { }

        public DbSet<CartItem> Cart { get; set; }
    }
}
