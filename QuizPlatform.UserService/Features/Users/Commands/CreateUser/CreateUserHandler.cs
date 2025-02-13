using MediatR;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services;
using QuizPlatform.UserService.Services.Interfaces;
using RabbitMQ.Client;

namespace QuizPlatform.UserService.Features.Users.Commands.CreateUser;

public class CreateUserHandler(IUserService userService,IConnection connection) : IRequestHandler<CreateUserCommand, User>
{
    private readonly IConnection _connection = connection;
    
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var utente= new User()
        {
            Name = request.utente.Name,
            Surname = request.utente.Surname,
            Email = request.utente.Email,
            Password = request.utente.Password,
        };
        return await userService.CreateNewUser(utente);
    }
}