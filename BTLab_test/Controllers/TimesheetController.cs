using BTLab_test.Data;
using BTLab_test.Models.TimesheetData;
using BTLab_test.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTLab_test.Controllers
{
    public class TimesheetController:Controller
    {
        private TimesheetDbContext timesheetDbContext;
        public TimesheetController(TimesheetDbContext timesheetDbContext)
        {
            this.timesheetDbContext = timesheetDbContext;
        }


        [HttpGet]
        [HttpPost]
        public IActionResult TimesheetPage()
        {
            var employees = timesheetDbContext.Employees.ToList();
            var timesheet = timesheetDbContext.Timesheets.ToList();
            ViewBag.Employees = employees;
            ViewBag.Timesheets = timesheet;
            var timesheets = timesheetDbContext.Timesheets.Include(t => t.Employee).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddTimesheetRequest addTimesheetRequest)
        {
            if (ModelState.IsValid)
            {
                var timesheet = new Timesheet
                {
                    Reason = Convert.ToInt32(addTimesheetRequest.Reason),
                    StartDate = addTimesheetRequest.StartDate,
                    Duration = addTimesheetRequest.Duration,
                    Discounted = addTimesheetRequest.Discounted,
                    Description = addTimesheetRequest.Description,
                    EmployeeId = addTimesheetRequest.EmployeeId
                };

                timesheetDbContext.Add(timesheet);
                timesheetDbContext.SaveChanges();

                
                return RedirectToAction("TimesheetPage");
            }

            return RedirectToAction("TimesheetPage");
        }

        public IActionResult Timesheet()
        {
            var timesheets = timesheetDbContext.Timesheets.Include(t => t.Employee).ToList();
            return View(timesheets);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var timesheet = timesheetDbContext.Timesheets.Find(id);
            if (timesheet != null)
            {
                timesheetDbContext.Timesheets.Remove(timesheet);
                timesheetDbContext.SaveChanges();
                return Ok(); 
            }
            return NotFound(); 
        }

    }
}
