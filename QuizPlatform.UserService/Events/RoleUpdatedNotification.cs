using MediatR;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Events;

public class RoleUpdatedNotification:INotification
{
    public Role Ruolo { get; set; }
}

public class RoleUpdatedNotificationHandler(
    ILogger<RoleUpdatedNotificationHandler> logger,
    IKeycloakService keycloakService)
    : INotificationHandler<RoleUpdatedNotification>
{
    public async Task Handle(RoleUpdatedNotification notification, CancellationToken cancellationToken)
    {
        await keycloakService.UpdateRole(notification.Ruolo);
        logger.LogInformation($"Modificato ruolo {notification.Ruolo.Id} - {notification.Ruolo.Name}");
    }
}
