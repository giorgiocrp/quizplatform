using QuizPlatform.UserService.Model.Entities;

namespace QuizPlatform.UserService.Services.Interfaces;

public interface IRoleService
{
    Task<Role> CreateNewRole(Role ruolo);
}