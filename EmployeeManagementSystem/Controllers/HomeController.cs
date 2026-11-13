using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalEmployees = _context.Employees.Count();
            ViewBag.TotalLeaves = _context.Leaves.Count();
            ViewBag.PendingLeaves = _context.Leaves.Count(l => l.Status == "Pending");
            ViewBag.ApprovedLeaves = _context.Leaves.Count(l => l.Status == "Approved");
            ViewBag.RejectedLeaves = _context.Leaves.Count(l => l.Status == "Rejected");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
