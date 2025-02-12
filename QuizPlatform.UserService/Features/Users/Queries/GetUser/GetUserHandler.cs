using MediatR;
using QuizPlatform.Db.Models;
using QuizPlatform.UserService.Services;

namespace QuizPlatform.UserService.Features.Users.Queries.GetUsers;

public class GetUserHandler:IRequestHandler<GetUserQuery,User>
{
    private readonly IUserService _userService;
    
    public GetUserHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetUser(request.id,cancellationToken);
    }
}