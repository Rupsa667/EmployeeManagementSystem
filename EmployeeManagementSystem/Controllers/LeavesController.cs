
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    public class LeavesController : Controller
    {
        private readonly AppDbContext _context;

        public LeavesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var leaves = _context.Leaves.Include(l => l.Employee).ToList();

            return View(leaves);
        }
        public IActionResult Create()
        {
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Leave leave)
        {
            if (leave.FromDate > leave.ToDate)
            {
                ModelState.AddModelError("ToDate", "To Date must be after From Date");
            }

            if (ModelState.IsValid)
            {
                leave.Status = "Pending";

                _context.Leaves.Add(leave);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Employees = _context.Employees.ToList();
            return View(leave);
        }
        [HttpPost]
        public IActionResult Approve(int id)
        {
            var leave = _context.Leaves.Find(id);

            if (leave != null)
            {
                leave.Status = "Approved";
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            var leave = _context.Leaves.Find(id);

            if (leave != null)
            {
                leave.Status = "Rejected";
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }



    }
}