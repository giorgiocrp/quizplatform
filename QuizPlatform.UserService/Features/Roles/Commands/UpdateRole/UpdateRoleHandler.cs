using AutoMapper;
using MediatR;
using QuizPlatform.UserService.Features.Roles.Commands.DeleteRole;
using QuizPlatform.UserService.Features.Roles.DTOs;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services.Interfaces;
using RabbitMQ.Client;

namespace QuizPlatform.UserService.Features.Roles.Commands.UpdateRole;

public record UpdateRoleCommand(UpdateRoleDto ruolo) : IRequest<Role>;

public class UpdateRoleHandler(IRoleService roleService, IConnection connection, IMapper mapper)
    : IRequestHandler<UpdateRoleCommand, Role>
{
    private readonly IConnection _connection = connection;
    private readonly IMapper _mapper=mapper;


    public async Task<Role> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var ruolo = _mapper.Map<Role>(request.ruolo);
        return await roleService.UpdateRole(ruolo);
    }
}