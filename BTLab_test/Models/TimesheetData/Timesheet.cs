namespace BTLab_test.Models.TimesheetData
{
    public class Timesheet
    {
        public Guid Id { get; set; }
        public int Reason { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public bool Discounted { get; set; }
        public string Description { get; set; }
        
        public Guid EmployeeId { get; set; }

        
        public Employee Employee { get; set; }
    }
}
