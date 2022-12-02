using Microsoft.EntityFrameworkCore;
using TeamFriOne_Model.Context;
using TeamFriOne_Model.Model;

namespace TeamFriOne_Model.Repositories
{
    public interface IPayrollRepository : IBaseRepository<Payroll>
    {

    }
    public class PayrollRepository : BaseRepository<Payroll>, IPayrollRepository
    {
        public PayrollRepository(AppDbContext context) : base(context)
        {
        }
    }
}
