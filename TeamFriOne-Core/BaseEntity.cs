namespace TeamFriOne_Core
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool Deleted { get; set; }
    }
    public class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }
        public virtual bool Deleted { get; set; }
    }
}
