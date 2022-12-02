using TeamFriOne_Model.Model;
using TeamFriOne_Model.Repositories;

namespace TeamFriOne_Infrastructure.Services
{
    public interface IVacationService : IBaseService<UserVacation>
    {
    }
    public class VacationService : BaseService<UserVacation>, IVacationService
    {
        public VacationService(IVacationRepository vacationRepository) : base(vacationRepository)
        {
        }
    }
}
