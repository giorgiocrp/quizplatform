namespace QuizPlatform.UserService.Model.Entities;

public class Role:EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
}