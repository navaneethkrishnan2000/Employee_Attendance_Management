using EmployeeAttendanceManagementSystem.Data;
using EmployeeAttendanceManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace EmployeeAttendanceManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        //To show the Attendence List
        public IActionResult Index()
        {
            List<Attendance> attendanceObj = _context.Attendences.Include(a => a.Employee).ToList();
            return View(attendanceObj);
        }

        // To show the Create page
        public IActionResult Create()
        {
            var employees = _context.Employees.ToList();
            ViewBag.EmployeeList = employees;

            return View();
        }

        //To mark an attendance for an employee
        [HttpPost]
        public IActionResult Create(Attendance attendanceobj)
        {
            if (ModelState.IsValid)
            {
                _context.Attendences.Add(attendanceobj);
                _context.SaveChanges();
                return RedirectToAction("Index", "Attendance");
            }
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }
            Attendance? attendanceObj = _context.Attendences.Find(id);
            if (attendanceObj == null)
            {
                return NotFound();
            }
            return View(attendanceObj);
        }

        [HttpPost]
        public IActionResult Edit(Attendance attendanceObj)
        {
            if (ModelState.IsValid)
            {
                _context.Attendences.Update(attendanceObj);
                _context.SaveChanges();
                return RedirectToAction("Index", "Attendance");
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
            Attendance? attendanceObj = _context.Attendences.Find(id);
            if (attendanceObj == null)
            {
                return NotFound();
            }
            return View(attendanceObj);
        }

        [HttpPost]
        [DisplayName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Attendance? attendanceObj = _context.Attendences.Find(id);
            if (attendanceObj == null)
            {
                return NotFound();
            }

            _context.Attendences.Remove(attendanceObj);
            _context.SaveChanges();
            return RedirectToAction("Index", "Attendance");
        }
    }
}
