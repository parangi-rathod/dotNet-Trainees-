using Microsoft.EntityFrameworkCore;
using RepoPatternSports.Repository.Models;
//using RepoPatternSports.Service.Interface;

namespace RepoPatternSports.Repository
{
    public class AppDbContext : DbContext
    {
        //private readonly IPasswordHash _passwordHash;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
