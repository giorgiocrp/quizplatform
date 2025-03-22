using MediatR;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Events;

public class RoleCreatedNotification:INotification
{
    public Role Ruolo { get; set; }
}

public class RoleCreatedNotificationHandler(
    ILogger<RoleCreatedNotificationHandler> logger,
    IKeycloakService keycloakService)
    : INotificationHandler<RoleCreatedNotification>
{
    // public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
    // {
    //     await keycloakService.CreateUser(notification.Utente);
    //     logger.LogInformation($"Creato utente {notification.Utente.Id} - {notification.Utente.Email}");
    // }
    public async Task Handle(RoleCreatedNotification notification, CancellationToken cancellationToken)
    {
        await keycloakService.CreateRole(notification.Ruolo);
        logger.LogInformation($"Creato ruolo {notification.Ruolo.Id} - {notification.Ruolo.Name}");
    }
}