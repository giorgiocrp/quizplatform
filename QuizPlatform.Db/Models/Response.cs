namespace QuizPlatform.Db.Models;

public class Response
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Description { get; set; }
    public int Votes { get; set; }
    public int Order { get; set; }
    public virtual Request Request { get; set; }
}