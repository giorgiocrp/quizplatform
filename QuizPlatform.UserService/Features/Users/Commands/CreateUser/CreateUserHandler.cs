using AutoMapper;
using MediatR;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services;
using QuizPlatform.UserService.Services.Interfaces;
using RabbitMQ.Client;

namespace QuizPlatform.UserService.Features.Users.Commands.CreateUser;

public class CreateUserHandler(IUserService userService,IConnection connection, IMapper mapper) : IRequestHandler<CreateUserCommand, User>
{
    private readonly IConnection _connection = connection;
    private readonly IMapper _mapper=mapper;
    
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    { 
        var utente = _mapper.Map<User>(request.utente);
        return await userService.CreateNewUser(utente);
    }
}