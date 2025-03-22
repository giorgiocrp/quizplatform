namespace QuizPlatform.UserService.Features.Users.DTOs;

public class UpdateUserDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<int> RuoloIds { get; set; }
}