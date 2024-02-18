using BTLab_test.Models.TimesheetData;
using Microsoft.EntityFrameworkCore;

namespace BTLab_test.Data
{
    public class TimesheetDbContext : DbContext
    {
        public TimesheetDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
