

using QuizPlatform.UserService.Model.Entities;

namespace QuizPlatform.UserService.Services.Interfaces;

public interface IUserService
{
    Task<ICollection<User>> GetUsers(CancellationToken cancellationToken);
    Task<User> GetUser(int requestId, CancellationToken cancellationToken);
    Task<User> CreateNewUser(User utente);
    Task<ICollection<User>> GetUserByRole(int requestId, CancellationToken cancellationToken);
    Task DeleteUser(int requestId);
    Task<User> UpdateUser(User utente);
}