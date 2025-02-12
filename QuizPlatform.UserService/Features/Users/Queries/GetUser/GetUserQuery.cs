using MediatR;
using QuizPlatform.Db.Models;

namespace QuizPlatform.UserService.Features.Users.Queries.GetUsers;

public record GetUserQuery(int id) : IRequest<User>;
