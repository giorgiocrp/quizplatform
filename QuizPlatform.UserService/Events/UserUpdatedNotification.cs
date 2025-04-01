using MediatR;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Services.Interfaces;

namespace QuizPlatform.UserService.Events;

public class UserUpdatedNotification:INotification
{
    public User Utente { get; set; }
}

public class UserUpdatedNotificationHandler(
    ILogger<UserUpdatedNotificationHandler> logger,
    IKeycloakService keycloakService)
    : INotificationHandler<UserUpdatedNotification>
{
    public async Task Handle(UserUpdatedNotification notification, CancellationToken cancellationToken)
    {
        await keycloakService.CreateUser(notification.Utente);
        logger.LogInformation($"Modificato utente {notification.Utente.Id} - {notification.Utente.Email}");
    }
}