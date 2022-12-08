using Microsoft.AspNetCore.Mvc;
using TeamFriOne_Infrastructure.Services;
using TeamFriOne_Model.Model;

namespace TeamFriOne_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollController : BaseController<Payroll>
    {
        private readonly IPayrollService _rollService;
        public PayrollController(IPayrollService payrollService) : base(payrollService)
        {
            _rollService = payrollService;
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, Payroll newPayroll)
        {
            var payroll = await _rollService.GetByIdAsync(id);
            if (payroll is null)
                return NotFound();

            payroll.Total = newPayroll.Total;
            payroll.Rate = newPayroll.Rate;
            payroll.Date = newPayroll.Date;
            payroll.Hours = newPayroll.Hours;

            await _rollService.UpdateAsync(payroll);

            return Ok(payroll);
        }
    }
}
