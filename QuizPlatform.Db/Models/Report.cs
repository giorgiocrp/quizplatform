namespace QuizPlatform.Db.Models;

public class Report
{
    public Guid Id { get; set; }
    public Quiz Quiz { get; set; }
}