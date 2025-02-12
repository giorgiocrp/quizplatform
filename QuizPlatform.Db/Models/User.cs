using Microsoft.AspNetCore.Identity;

namespace QuizPlatform.Db.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public bool IsRegistered { get; set; } // Differenzia utenti registrati da ospiti
    public virtual List<Group> Groups { get; set; } = new();
    public virtual Role Role { get; set; } // Admin, RegisteredUser, Guest
}