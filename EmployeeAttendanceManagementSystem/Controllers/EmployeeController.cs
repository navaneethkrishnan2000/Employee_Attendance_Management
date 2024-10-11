using EmployeeAttendanceManagementSystem.Data;
using EmployeeAttendanceManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendanceManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // To show the Employee List
        public IActionResult Index()
        {
            List<Employee> employeeList = _context.Employees.ToList();
            return View(employeeList);
        }

        //To show the create page
        public IActionResult Create()
        {
            List<string> departments = new List<string>
            {
                "HR",
                "IT",
                "Finance",
                "Sales",
                "Marketing"
            };
            ViewBag.DepartmentsList = departments;

            return View();
        }

        //To create a New Employee
        [HttpPost]
        public IActionResult Create(Employee employeeObj)
        {
            //if (!ModelState.IsValid)
            //{
            //    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            //    {
            //        Console.WriteLine(error.ErrorMessage);
            //    }
            //    return View(employeeObj);
            //}
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employeeObj);
                _context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }

        // To show the edit page
        public IActionResult Edit(int? id)
        {
            if( id == 0 || id == null)
            {
                return NotFound();
            }

            Employee? employeeObj = _context.Employees.Find(id);

            if (employeeObj == null) 
            {
                return NotFound();
            }

            return View(employeeObj);
        }

        //To edit the employee details
        [HttpPost]
        public IActionResult Edit(Employee employeeObj)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employeeObj);
                _context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }

        // To show the delete form
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Employee? employeeObj = _context.Employees.Find(id);

            if (employeeObj == null)
            {
                return NotFound();
            }

            return View(employeeObj);
        }

        // To handle employee deletion
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Employee? employeeObj = _context.Employees.Find(id);
            if(employeeObj == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employeeObj);
            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
    }
}
