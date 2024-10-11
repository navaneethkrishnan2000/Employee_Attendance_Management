using System.ComponentModel.DataAnnotations;

namespace EmployeeAttendanceManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string? Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string? Email { get; set; }

        [Required (ErrorMessage ="Department is required")]
        public string? Department { get; set; }

        public ICollection<Attendance>? Attendances { get; set; }
    }
}
