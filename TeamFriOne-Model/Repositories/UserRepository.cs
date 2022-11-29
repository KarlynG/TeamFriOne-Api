using Microsoft.EntityFrameworkCore;
using TeamFriOne_Model.Context;
using TeamFriOne_Model.Model;

namespace TeamFriOne_Model.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();
        Task<User> AddUser(User user);
        Task<User> DeleteUser(int id);
        
    }
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return result ?? new User();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            var entity = await GetUserById(id);
            var result = _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
