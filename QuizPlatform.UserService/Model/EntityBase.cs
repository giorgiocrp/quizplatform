namespace QuizPlatform.UserService.Model;

public abstract class EntityBase
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public DateTimeOffset Created { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset LastModified { get; private set; } = DateTimeOffset.UtcNow;
    
    public void UpdateLastModified()
    {
        LastModified = DateTimeOffset.UtcNow;
    }
}