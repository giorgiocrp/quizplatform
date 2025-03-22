using MediatR;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Events;



public class UserDeletedNotification:INotification
{
    public int Id { get; set; }
}

public class UserDeletedNotificationHandler(
    ILogger<UserDeletedNotificationHandler> logger,
    IKeycloakService keycloakService)
    : INotificationHandler<UserDeletedNotification>
{
    // public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
    // {
    //     await keycloakService.CreateUser(notification.Utente);
    //     logger.LogInformation($"Creato utente {notification.Utente.Id} - {notification.Utente.Email}");
    // }
    public async Task Handle(UserDeletedNotification notification, CancellationToken cancellationToken)
    {
        await keycloakService.DeleteUser(notification.Id);
        logger.LogInformation($"Eliminato utente {notification.Id}");
    }
}
