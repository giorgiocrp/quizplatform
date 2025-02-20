using MediatR;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Features.Users.Queries.GetUserByRole;

public record GetUserByRoleQuery(int id) : IRequest<ICollection<User>>;

public class GetUserByRoleHandler:IRequestHandler<GetUserByRoleQuery,ICollection<User>>
{
    private readonly IUserService _userService;
    
    public GetUserByRoleHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<ICollection<User>> Handle(GetUserByRoleQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetUserByRole(request.id,cancellationToken);
    }
}