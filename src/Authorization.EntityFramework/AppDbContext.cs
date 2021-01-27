using Microsoft.EntityFrameworkCore;

namespace Authorization.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tariff>? Tariffs { get; set; }
    }
}