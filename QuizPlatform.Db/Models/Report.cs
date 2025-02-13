namespace QuizPlatform.Db.Models;

public class Report
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public Quiz Quiz { get; set; }
}