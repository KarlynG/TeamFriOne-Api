using Microsoft.AspNetCore.Mvc;
using TeamFriOne_Infrastructure.Services;
using TeamFriOne_Model.Model;

namespace TeamFriOne_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacationController : BaseController<UserVacation>
    {
        private readonly IVacationService _vacationService;
        public VacationController(IVacationService vacationService) : base(vacationService)
        {
            _vacationService = vacationService;
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, UserVacation newVacation)
        {
            var vacation = await _vacationService.GetByIdAsync(id);
            if (vacation is null)
                return NotFound();

            vacation.StartDate = newVacation.StartDate;
            vacation.EndDate = newVacation.EndDate;
            vacation.Reason = newVacation.Reason;

            await _vacationService.UpdateAsync(vacation);

            return Ok(vacation);
        }
    }
}
