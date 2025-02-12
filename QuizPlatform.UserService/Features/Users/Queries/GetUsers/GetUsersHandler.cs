using MediatR;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services;

namespace QuizPlatform.UserService.Features.Users.Queries.GetUsers;

public class GetUsersHandler:IRequestHandler<GetUsersQuery,ICollection<User>>
{
    private readonly IUserService _userService;
    
    public GetUsersHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<ICollection<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetUsers(cancellationToken);
    }
}