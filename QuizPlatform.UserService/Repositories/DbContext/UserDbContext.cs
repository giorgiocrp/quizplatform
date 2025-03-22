using Microsoft.EntityFrameworkCore;
using QuizPlatform.Db;
using QuizPlatform.Db.Models;

namespace QuizPlatform.UserService.Repositories.DbContext;

public class UserDbContext(DbContextOptions<UserDbContext> options): Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<User> Users { get; set; } 
    public DbSet<Role> Roles { get; set; } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("QuizDataDb");
        
        base.OnModelCreating(modelBuilder);
    }
}