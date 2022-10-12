using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository;

public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(x =>
        {
            x.HasKey(e => e.Id);

            x.Property(e => e.Id)
                .ValueGeneratedOnAdd();
        });
    }
}