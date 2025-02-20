using MediatR;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Features.Roles.Queries.GetRoleById;

public record GetRoleByIdQuery(int id): IRequest<Role>;

public class GetRoleByIdHandler:IRequestHandler<GetRoleByIdQuery,Role>
{
    private readonly IRoleService _roleService;
    
    public GetRoleByIdHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    
    public async Task<Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return await _roleService.GetRole(request.id, cancellationToken);
    }
}