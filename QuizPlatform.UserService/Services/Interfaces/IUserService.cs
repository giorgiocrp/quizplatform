

using QuizPlatform.UserService.Model.Entities;

namespace QuizPlatform.UserService.Services;

public interface IUserService
{
    Task<ICollection<User>> GetUsers(CancellationToken cancellationToken);
    Task<User> GetUser(int requestId, CancellationToken cancellationToken);
    Task<User> CreateNewUser(User utente);
}