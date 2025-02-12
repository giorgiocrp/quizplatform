

using QuizPlatform.UserService.Model.Entities;

namespace QuizPlatform.UserService.Services;

public class UserService:IUserService
{
    public async Task<ICollection<User>> GetUsers(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUser(int requestId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<User> CreateNewUser(User utente)
    {
        throw new NotImplementedException();
    }
}