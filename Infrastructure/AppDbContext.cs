using ClientsWebApi_v2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientsWebApi_v2.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Founder> Founders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Inn)
                .IsRequired()
                .HasMaxLength(12);

            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Type)
                .IsRequired();

            entity.Property(c => c.DateCreated)
                .IsRequired();

            entity.Property(c => c.DateModified)
                .IsRequired();

            entity.HasMany(c => c.Founders)
                .WithOne(f => f.Client)
                .HasForeignKey(f => f.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Founder>(entity =>
        {
            entity.HasKey(f => f.Id);

            entity.Property(f => f.Inn)
                .IsRequired()
                .HasMaxLength(12);

            entity.Property(f => f.FullName)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(f => f.DateCreated)
                .IsRequired();

            entity.Property(f => f.DateModified)
                .IsRequired();
        });
    }
}