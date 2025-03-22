using QuizPlatform.UserService.Model.Entities;

namespace QuizPlatform.UserService.Services.Interfaces;

public interface IKeycloakService
{
    Task CreateUser(User notificationUtente);
    Task CreateRole(Role notificationRuolo);
    Task DeleteRole(int notificationId);
    Task DeleteUser(int notificationId);
}