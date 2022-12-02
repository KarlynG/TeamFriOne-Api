using Microsoft.EntityFrameworkCore;
using TeamFriOne_Model.Context;
using TeamFriOne_Model.Model;

namespace TeamFriOne_Model.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        
    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
