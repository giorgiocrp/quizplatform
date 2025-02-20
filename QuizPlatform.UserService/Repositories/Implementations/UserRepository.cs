using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizPlatform.Db.Models;
using QuizPlatform.UserService.Repositories.DbContext;
using QuizPlatform.UserService.Repositories.Interfaces;
using User = QuizPlatform.UserService.Model.Entities.User;

namespace QuizPlatform.UserService.Repositories.Implementations;

public class UserRepository:IUserRepository
{
    private readonly UserDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public UserRepository(UserDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public async Task<User> GetById(int id)
    {
        try
        {
            var utente = await _dbContext.Users.FindAsync(id);
            return _mapper.Map<User>(utente);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
            throw;
        }
    }
    
    public async Task<User> GetByGuid(string guid)
    {
        try
        {
            var utente = await _dbContext.Users.FirstOrDefaultAsync(t=>t.Guid.ToString()==guid);
            return _mapper.Map<User>(utente);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
            throw;
        }
    }

    public async Task<ICollection<User>> GetUserByRole(int requestId)
    {
        try
        {
            var utente = await _dbContext.Users.Where(t=>t.Role.Id==requestId).ToListAsync();
            return _mapper.Map<ICollection<User>>(utente);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
            throw;
        }
    }

    public async Task<ICollection<User>> GetUserByRoleGuid(string guid)
    {
        try
        {
            var utente = await _dbContext.Users.Where(t=>String.Equals(t.Role.Guid.ToString(),guid)).ToListAsync();
            return _mapper.Map<ICollection<User>>(utente);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
            throw;
        }
    }

    public async Task<ICollection<User>> GetAll()
    {
        try
        {
            var utenti = await _dbContext.Users.ToListAsync();
            return _mapper.Map<ICollection<User>>(utenti);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
            throw;
        }
    }

    public async Task<User> Add(User entity)
    {
        try
        {
            var utente = _mapper.Map<QuizPlatform.Db.Models.User>(entity);
            _dbContext.Users.Add(utente);
            await _dbContext.SaveChangesAsync();
            //entity.Id = utente.Id;
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
            throw;
        }
    }

    public async Task<User> Update(User entity)
    {
        try
        {
            var utente= _mapper.Map<QuizPlatform.Db.Models.User>(entity);
            _dbContext.Users.Update(utente);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<User>(utente);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
            throw;
        }
    }

    public async Task Delete(User entity)
    {
        try
        {
            var utente=_mapper.Map<QuizPlatform.Db.Models.User>(entity);
            _dbContext.Users.Remove(utente);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
            throw;
        }
    }
}