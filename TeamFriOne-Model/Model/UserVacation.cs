using TeamFriOne_Core;

namespace TeamFriOne_Model.Model
{
    public class UserVacation : BaseEntity
    {
        public int UserId { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
