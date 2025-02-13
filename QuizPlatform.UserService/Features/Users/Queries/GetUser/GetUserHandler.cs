using MediatR;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Features.Users.Queries.GetUser;

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