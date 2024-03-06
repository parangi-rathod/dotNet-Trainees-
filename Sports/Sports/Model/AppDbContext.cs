using Microsoft.EntityFrameworkCore;
using Sports.Repository;

namespace Sports.Model
{
    public class AppDbContext : DbContext
    {
        private readonly IConvertHashService _convertHashService;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConvertHashService convertHashService) : base(options)
        {
            _convertHashService= convertHashService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                    modelBuilder.Entity<User>()
               .Property(u => u.Password)
               .HasColumnType("nvarchar(max)")
               .IsRequired();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Firstname = "zenisha",
                    Lastname = "savaliya",
                    Password = _convertHashService.CreatePasswordHash("team1234"),
                    TotalMatchesPlayed = 0,
                    ContactNumber = "9586842849",
                    Email = "zenishasavaliya96@gmail.com",
                    DateOfBirth = new DateTime(2003, 08, 15),
                    role = Role.Coach,
                    isMember = false
                }
       );
        }
        public DbSet<User> UserModel{ get; set; }

    }
}
