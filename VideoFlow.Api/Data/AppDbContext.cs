namespace VideoFlow.Api.Data;

using Microsoft.EntityFrameworkCore;
using VideoFlow.Api.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Video> Videos { get; set; }
}