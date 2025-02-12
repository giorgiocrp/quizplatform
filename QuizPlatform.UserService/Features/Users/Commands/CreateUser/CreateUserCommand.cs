using MediatR;
using QuizPlatform.UserService.Features.Users.DTOs;
using QuizPlatform.UserService.Model.Entities;

namespace QuizPlatform.UserService.Features.Users.Commands.CreateUser;

public record CreateUserCommand(CreateUserDto utente):IRequest<User>;