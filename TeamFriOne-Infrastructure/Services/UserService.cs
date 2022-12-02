using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamFriOne_Model.Model;
using TeamFriOne_Model.Repositories;

namespace TeamFriOne_Infrastructure.Services
{
    public interface IUserService : IBaseService<User>
    {
    }
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
        }
    }
}
