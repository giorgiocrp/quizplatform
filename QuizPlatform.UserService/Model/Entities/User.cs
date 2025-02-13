namespace QuizPlatform.UserService.Model.Entities;

public class User:EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }
    public bool IsRegistered { get; set; } // Differenzia utenti registrati da ospiti
}