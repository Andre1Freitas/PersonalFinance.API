using Microsoft.EntityFrameworkCore;
using PersonalFinance.API.Entities;

namespace PersonalFinance.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
