using User = QuizPlatform.UserService.Model.Entities.User;

namespace QuizPlatform.UserService.Repositories.Interfaces;

public interface IUserRepository:IBaseRepository<User>
{
    Task<User> GetByGuid(string guid);
    Task<ICollection<User>> GetUserByRole(int requestId);
    Task<ICollection<User>> GetUserByRoleGuid(string guid);
}