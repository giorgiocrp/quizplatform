using MediatR;
using QuizPlatform.UserService.Features.Roles.DTOs;
using QuizPlatform.UserService.Features.Users.Commands.CreateUser;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services;
using QuizPlatform.UserService.Services.Interfaces;
using RabbitMQ.Client;

namespace QuizPlatform.UserService.Features.Roles.Commands.CreateRole;

public record CreateRoleCommand(CreateRoleDto role):IRequest<Role>;

public class CreateRoleHandler(IRoleService roleService,IConnection connection) : IRequestHandler<CreateRoleCommand, Role>
{
    private readonly IConnection _connection = connection;

    public async Task<Role> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var ruolo = new Role()
        {
            Name = request.role.Name
        };
        return await roleService.CreateNewRole(ruolo);
    }
}