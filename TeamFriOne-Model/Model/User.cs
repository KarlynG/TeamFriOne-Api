using TeamFriOne_Core;

namespace TeamFriOne_Model.Model
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public UserVacation? UserVacations { get; set; }
        public Payroll? Payroll { get; set; }
    }
}
