using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string EmpPhone { get; set; } = null!;

        public decimal Salary { get; set; }

        public DateTime JoiningDate { get; set; }
    }
}

