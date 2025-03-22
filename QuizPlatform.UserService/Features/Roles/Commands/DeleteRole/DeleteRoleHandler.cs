using MediatR;
using QuizPlatform.UserService.Features.Roles.Commands.CreateRole;
using QuizPlatform.UserService.Services.Interfaces;
using RabbitMQ.Client;

namespace QuizPlatform.UserService.Features.Roles.Commands.DeleteRole;

public record DeleteRoleCommand(int id):IRequest;

public class DeleteRoleHandler(IRoleService roleService,IConnection connection) : IRequestHandler<DeleteRoleCommand>
{
    private readonly IConnection _connection = connection;


    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        await  roleService.DeleteRole(request.id);
    }
}