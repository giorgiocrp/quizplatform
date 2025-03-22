using AutoMapper;
using MediatR;
using QuizPlatform.UserService.Features.Users.Commands.DeleteUser;
using QuizPlatform.UserService.Features.Users.DTOs;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services.Interfaces;
using RabbitMQ.Client;

namespace QuizPlatform.UserService.Features.Users.Commands.UpdateUser;

public record UpdateUserCommand(UpdateUserDto utente):IRequest<User>;

public class UpdateUserHandler(IUserService userService,IConnection connection, IMapper mapper) : IRequestHandler<UpdateUserCommand,User>
{
    private readonly IConnection _connection = connection;
    private readonly IMapper _mapper=mapper;

    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var utente = _mapper.Map<User>(request.utente);
        return await userService.UpdateUser(utente);
    }
}
