using Microsoft.EntityFrameworkCore;

namespace QuizPlatform.QuizService.Repositories.DbContext;

public class QuizDbContext(DbContextOptions<QuizDbContext> options): Microsoft.EntityFrameworkCore.DbContext(options)
{
    // public DbSet<User> Users { get; set; } 
    // public DbSet<Role> Roles { get; set; } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.HasDefaultSchema("QuizDataDb");
        
        base.OnModelCreating(modelBuilder);
    }
}