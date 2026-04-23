namespace VideoFlow.Api.Data;

using Microsoft.EntityFrameworkCore;
using VideoFlow.Api.Users;
using VideoFlow.Api.Videos;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Video> Videos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Video>()
            .HasIndex(v => v.UserId)
            .HasDatabaseName("idx_videos_user_id");

        modelBuilder.Entity<Video>()
            .HasIndex(v => v.CreatedAt)
            .HasDatabaseName("idx_videos_created_at");

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("idx_users_email_unique");
    }
}