using MediatR;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Events;

public class RoleDeletedNotification:INotification
{
    public int Id { get; set; }
}

public class RoleDeletedNotificationHandler(
    ILogger<RoleDeletedNotificationHandler> logger,
    IKeycloakService keycloakService)
    : INotificationHandler<RoleDeletedNotification>
{
    // public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
    // {
    //     await keycloakService.CreateUser(notification.Utente);
    //     logger.LogInformation($"Creato utente {notification.Utente.Id} - {notification.Utente.Email}");
    // }
    public async Task Handle(RoleDeletedNotification notification, CancellationToken cancellationToken)
    {
        await keycloakService.DeleteRole(notification.Id);
        logger.LogInformation($"Eliminato ruolo {notification.Id}");
    }
}