namespace QuizPlatform.Db.Models;

public class Request
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public bool IsVisible { get; set; }
    public virtual Quiz Quiz { get; set; }
}