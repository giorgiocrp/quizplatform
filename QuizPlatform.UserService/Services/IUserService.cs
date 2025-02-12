using QuizPlatform.Db.Models;

namespace QuizPlatform.UserService.Services;

public interface IUserService
{
    Task<ICollection<User>> GetUsers(CancellationToken cancellationToken);
    Task<User> GetUser(int requestId, CancellationToken cancellationToken);
}