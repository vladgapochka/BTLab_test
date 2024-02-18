namespace BTLab_test.Models.TimesheetData
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Timesheet> Timesheets { get; set; }
    }
}
