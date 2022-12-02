using Microsoft.AspNetCore.Mvc;
using TeamFriOne_Infrastructure.Services;
using TeamFriOne_Model.Model;

namespace TeamFriOne_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController<User>
    {
        private readonly IUserService _userService;
        private readonly IVacationService _vacationService;
        private readonly IPayrollService _rollService;
        public UserController(
            IUserService userService, 
            IVacationService vacationService, 
            IPayrollService payrollService) : base(userService)
        {
            _userService = userService;
            _vacationService = vacationService;
            _rollService = payrollService;
        }
        [HttpGet("{id}")]
        public override async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            var payrolls = await _rollService.GetAllAsync();
            var vacations = await _vacationService.GetAllAsync();

            var userPayroll = payrolls.Where(x => x.UserId == id);
            var userVacation = vacations.Where(x => x.UserId == id);

            if (userPayroll.Any())
                user.Payroll = userPayroll.FirstOrDefault();

            if (userVacation.Any())
                user.UserVacations = userVacation.FirstOrDefault();

            return Ok(user);
        }
    }
}


