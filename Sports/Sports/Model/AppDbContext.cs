using Microsoft.EntityFrameworkCore;

namespace Sports.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> UserModel{ get; set; }
    }
}
