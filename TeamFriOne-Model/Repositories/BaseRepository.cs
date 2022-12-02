using Microsoft.EntityFrameworkCore;
using TeamFriOne_Core;
using TeamFriOne_Model.Context;

namespace TeamFriOne_Model.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Delete(int id);
        Task<TEntity> Get(int id);
        Task<List<TEntity>> GetAll();
    }
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _set;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            var result = await _set.AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await Get(id);

            var result = _set.Remove(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<TEntity> Get(int id)
        {
            var entity = await _set.Where(x => x.Id == id).FirstOrDefaultAsync();
            
            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _set.ToListAsync();
        }
    }
}
