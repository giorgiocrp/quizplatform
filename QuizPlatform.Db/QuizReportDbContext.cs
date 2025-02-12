using Microsoft.EntityFrameworkCore;
using QuizPlatform.Db.Models;

namespace QuizPlatform.Db;

public class QuizReportDbContext(DbContextOptions<QuizReportDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Report> Reports { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("QuizReportDb");
        
        base.OnModelCreating(modelBuilder);
    }
}