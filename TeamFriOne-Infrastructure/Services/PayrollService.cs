using TeamFriOne_Model.Model;
using TeamFriOne_Model.Repositories;

namespace TeamFriOne_Infrastructure.Services
{
    public interface IPayrollService : IBaseService<Payroll>
    {
    }
    public class PayrollService : BaseService<Payroll>, IPayrollService
    {
        public PayrollService(IPayrollRepository payrollRepository) : base(payrollRepository)
        {
        }
    }
}
