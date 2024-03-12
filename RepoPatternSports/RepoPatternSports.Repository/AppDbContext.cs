using Microsoft.EntityFrameworkCore;
using RepoPatternSports.Repository.Models;

namespace RepoPatternSports.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Firstname = "Parangi",
                    Lastname = "Rathod",
                    Password = "a2b33e9987e8c254361bcafced58a245ea7ba919eaf093119694a68e01bd59fe",
                    TotalMatchesPlayed = 0,
                    ContactNumber = "9726976891",
                    Email = "parangirathod27@gmail.com",
                    DateOfBirth = new DateTime(2002, 12, 27),
                    role = Role.Coach,
                    Height = 0,
                    Weight = 0,
                    isMember = false,
                }
                );

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
               .Property(u => u.Password)
               .HasColumnType("nvarchar(max)")
               .IsRequired();
        }
        public DbSet<User> UserModel { get; set; }
    }
}
