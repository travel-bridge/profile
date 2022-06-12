using Microsoft.EntityFrameworkCore;
using ProfileAggregate = Profile.Domain.Aggregates.ProfileAggregate;

namespace Profile.Infrastructure.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("profile");

        modelBuilder.Entity<ProfileAggregate.Profile>().ToTable("Profile");

        modelBuilder.Entity<ProfileAggregate.Profile>().Property(x => x.CreateDateTimeUtc).HasConversion(
            x => DateTime.SpecifyKind(x, DateTimeKind.Utc),
            x => DateTime.SpecifyKind(x, DateTimeKind.Utc));
        
        modelBuilder.Entity<ProfileAggregate.Profile>().Property(x => x.UpdateDateTimeUtc).HasConversion(
            x => x.HasValue ? DateTime.SpecifyKind(x.Value, DateTimeKind.Utc) : (DateTime?)null,
            x => x.HasValue ? DateTime.SpecifyKind(x.Value, DateTimeKind.Utc) : null);
    }
}