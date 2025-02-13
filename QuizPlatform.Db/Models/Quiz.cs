namespace QuizPlatform.Db.Models;

public class Quiz
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public virtual User Author { get; set; }
    public virtual Group Group { get; set; }
    public virtual List<Request> Requests { get; set; } = new();
}