using MediatR;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Features.Roles.Queries.GetRoles;

public record GetRolesQuery(): IRequest<ICollection<Role>>;

public class GetRolesHandler:IRequestHandler<GetRolesQuery,ICollection<Role>>
{
    private readonly IRoleService _roleService;
    
    public GetRolesHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    
    public async Task<ICollection<Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return await _roleService.GetRoles(cancellationToken);
    }
}