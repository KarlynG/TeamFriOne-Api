using Microsoft.EntityFrameworkCore;
using TeamFriOne_Model.Context;
using TeamFriOne_Model.Model;

namespace TeamFriOne_Model.Repositories
{
    public interface IVacationRepository : IBaseRepository<UserVacation>
    {

    }
    public class VacationRepository : BaseRepository<UserVacation>, IVacationRepository
    {
        public VacationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
