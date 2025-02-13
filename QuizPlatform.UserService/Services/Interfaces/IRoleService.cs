using QuizPlatform.UserService.Model.Entities;

namespace QuizPlatform.UserService.Services;

public interface IRoleService
{
    Task<Role> CreateNewRole(Role ruolo);
}