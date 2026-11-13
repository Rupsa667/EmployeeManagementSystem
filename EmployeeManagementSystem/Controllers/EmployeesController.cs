using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var employees = _context.Employees.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                employees = employees.Where(e => e.Name.Contains(search)).ToList();
            }

            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(emp);
        }
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            _context.Employees.Update(emp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);

            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
        
    }
}

