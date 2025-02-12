using MediatR;
using QuizPlatform.UserService.Model.Entities;

namespace QuizPlatform.UserService.Features.Users.Queries.GetUser;

public record GetUserQuery(int id) : IRequest<User>;
