using TeamFriOne_Core;
using TeamFriOne_Model.Repositories;

namespace TeamFriOne_Infrastructure.Services
{
    public interface IBaseService<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity)
        Task<TEntity> DeleteAsync(int id);
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
    }
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity: class, IBaseEntity
    {
        protected readonly IBaseRepository<TEntity> _repository;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _repository = baseRepository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await _repository.Add(entity);
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _repository.Update(entity);
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.Get(id);
        }
    }
}
