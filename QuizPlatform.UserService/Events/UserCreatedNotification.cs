using MediatR;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Events;

public class UserCreatedNotification:INotification
{
    public User Utente { get; set; }
}

public class UserCreatedNotificationHandler(
    ILogger<UserCreatedNotificationHandler> logger,
    IKeycloakService keycloakService)
    : INotificationHandler<UserCreatedNotification>
{
    public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
    {
        await keycloakService.CreateUser(notification.Utente);
        logger.LogInformation($"Creato utente {notification.Utente.Id} - {notification.Utente.Email}");
    }
}
