using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Repositories.Interfaces;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Services.Implementations;

public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ICollection<User>> GetUsers(CancellationToken cancellationToken)
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> GetUser(int requestId, CancellationToken cancellationToken)
    {
        return await _userRepository.GetById(requestId);
    }

    public async Task<User> CreateNewUser(User utente)
    {
        throw new NotImplementedException();
    }
}