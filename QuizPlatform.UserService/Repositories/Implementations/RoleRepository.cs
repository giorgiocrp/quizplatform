using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizPlatform.UserService.Model.Entities;
using QuizPlatform.UserService.Repositories.DbContext;
using QuizPlatform.UserService.Repositories.Interfaces;

namespace QuizPlatform.UserService.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;

        public RoleRepository(UserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Role> Add(Role entity)
        {
            try
            {
                var ruolo = _mapper.Map<QuizPlatform.Db.Models.Role>(entity);
                _dbContext.Roles.Add(ruolo);
                await _dbContext.SaveChangesAsync();
                entity.Id = ruolo.Id;
                return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
                throw;
            }
        }

        public async Task Delete(Role entity)
        {
            try
            {
                var ruolo=_mapper.Map<QuizPlatform.Db.Models.Role>(entity);
                _dbContext.Roles.Remove(ruolo);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
                throw;
            }
        }

        public async Task<ICollection<Role>> GetAll()
        {
            try
            {
                var ruoli = await _dbContext.Roles.ToListAsync();
                return _mapper.Map<ICollection<Role>>(ruoli);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
                throw;
            }
        }

        public async Task<Role> GetById(int id)
        {
            try
            {
                var ruolo = await _dbContext.Roles.FindAsync(id);
                return _mapper.Map<Role>(ruolo);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
                throw;
            }
        }

        public async Task<Role> Update(Role entity)
        {
            try
            {
                var ruolo= _mapper.Map<QuizPlatform.Db.Models.Role>(entity);
                _dbContext.Roles.Update(ruolo);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<Role>(ruolo);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message: {e.Message} Inner: {e.InnerException}");
                throw;
            }
        }
    }
}
