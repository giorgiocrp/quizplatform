using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Repositories.Interfaces;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Services.Implementations;

public class RoleService:IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task<Role> CreateNewRole(Role ruolo)
    {
        throw new NotImplementedException();
    }

    public async Task<Role> GetRole(int requestId, CancellationToken cancellationToken)
    {
        return await _roleRepository.GetById(requestId);
    }

    public async Task<ICollection<Role>> GetRoles(CancellationToken cancellationToken)
    {
        return await _roleRepository.GetAll();
    }
}