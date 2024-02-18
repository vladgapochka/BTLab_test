using BTLab_test.Data;
using BTLab_test.Models.TimesheetData;
using BTLab_test.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BTLab_test.Controllers
{
    public class AdminEmployeeController : Controller
    {
        private TimesheetDbContext timesheetDbContext;
        public AdminEmployeeController(TimesheetDbContext timesheetDbContext)
        {
            this.timesheetDbContext = timesheetDbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(AddEmployeeRequest addEmployeeRequest)
        
        {
            var employee = new Employee
            {
                FirstName = addEmployeeRequest.FirstName,
                LastName = addEmployeeRequest.LastName
            };
            timesheetDbContext.Add(employee);
            timesheetDbContext.SaveChanges();
            return View("Add");
        }


        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = timesheetDbContext.Employees.ToList();
            return Json(employees);
        }


        [HttpPost]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = timesheetDbContext.Employees.Find(id);
            if (employee != null)
            {
                timesheetDbContext.Employees.Remove(employee);
                timesheetDbContext.SaveChanges();
            }

            return RedirectToAction("Add");
        }
    }
}
