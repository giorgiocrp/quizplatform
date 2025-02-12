using MediatR;
using QuizPlatform.UserService.Model.Entities;


namespace QuizPlatform.UserService.Features.Users.Queries.GetUsers;

public record GetUsersQuery() : IRequest<ICollection<User>>;
