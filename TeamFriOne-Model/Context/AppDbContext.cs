using Microsoft.EntityFrameworkCore;
using TeamFriOne_Model.Model;

namespace TeamFriOne_Model.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<UserVacation> UserVacations { get; set; }
    }
}
