using Microsoft.EntityFrameworkCore;

namespace Authorization.EntityFramework
{
    public class AppDbContext 
    {
        public DbSet<Tariff> Tariffs { get; set; }
    }
}