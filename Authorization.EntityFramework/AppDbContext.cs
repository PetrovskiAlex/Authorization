using Microsoft.EntityFrameworkCore;

namespace Authorization.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tariff> Tariffs { get; set; }
    }
}