using QuizPlatform.UserService.Model.Entities;

namespace QuizPlatform.UserService.Services.Interfaces;

public interface IRoleService
{
    Task<Role> CreateNewRole(Role ruolo);
    Task<ICollection<Role>> GetRoles(CancellationToken cancellationToken);
    Task<Role> GetRole(int requestId, CancellationToken cancellationToken);
}