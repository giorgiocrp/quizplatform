using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizPlatform.Db.Models;

namespace QuizPlatform.Db;

public class QuizDataDbContext(DbContextOptions<QuizDataDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Response> Responses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("QuizDataDb");
        
        base.OnModelCreating(modelBuilder);
    }
}