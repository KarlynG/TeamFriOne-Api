using Microsoft.AspNetCore.Mvc;
using TeamFriOne_Infrastructure.Services;
using TeamFriOne_Model.Model;

namespace TeamFriOne_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacationController : BaseController<UserVacation>
    {
        public VacationController(IVacationService vacationService) : base(vacationService)
        {
        }
    }
}
