namespace QuizPlatform.Db.Models;

public class Role
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public virtual List<User> Users { get; set; } = new();
}