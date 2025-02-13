namespace QuizPlatform.Db.Models;

public class Group
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public virtual List<User> Users { get; set; } = new();
    public virtual List<Quiz> Quizzes { get; set; } = new();
}