using Microsoft.EntityFrameworkCore;
using QuizPlatform.Db;
using QuizPlatform.Db.Models;

namespace QuizPlatform.UserService.Repositories.DbContext;

public class UserDbContext(DbContextOptions<QuizDataDbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<User> Users { get; set; }
}