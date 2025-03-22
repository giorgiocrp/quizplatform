using MediatR;
using QuizPlatform.UserService.Features.Roles.Commands.DeleteRole;
using QuizPlatform.UserService.Services.Interfaces;
using RabbitMQ.Client;

namespace QuizPlatform.UserService.Features.Users.Commands.DeleteUser;

public record DeleteUserCommand(int id):IRequest;

public class DeleteUserHandler(IUserService userService,IConnection connection) : IRequestHandler<DeleteUserCommand>
{
    private readonly IConnection _connection = connection;


    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await  userService.DeleteUser(request.id);
    }
}

