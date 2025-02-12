namespace QuizPlatform.Db.Models;

public class Quiz
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual User Author { get; set; }
    public virtual Group Group { get; set; }
    public virtual List<Request> Requests { get; set; } = new();
}