namespace QuizPlatform.UserService.Model.Entities;

public class User:EntityBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public bool IsRegistered { get; set; } // Differenzia utenti registrati da ospiti
}