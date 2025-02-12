namespace QuizPlatform.UserService.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    Task<T> GetById(int id);
    Task<ICollection<T>> GetAll();
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task Delete(T entity);
}