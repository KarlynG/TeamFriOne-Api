using TeamFriOne_Core;

namespace TeamFriOne_Model.Model
{
    public class Payroll : BaseEntity
    {
        public int UserId { get; set; }
        public string Date { get; set; } = string.Empty;
        public string Hours { get; set; } = string.Empty;
        public string Rate { get; set; } = string.Empty;
        public string Total { get; set; } = string.Empty;
    }
}
