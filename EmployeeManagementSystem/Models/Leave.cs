using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Leave
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public string LeaveType { get; set; } = null!;

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [Required]
        public string Reason { get; set; } = null!;

        public string Status { get; set; } = "Pending";

        public Employee? Employee { get; set; }
    }
}
