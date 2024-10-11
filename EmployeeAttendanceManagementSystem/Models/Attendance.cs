using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAttendanceManagementSystem.Models
{
    public class Attendance
    {
        [Key]
        public int AttendenceId {  get; set; }

        [DisplayName("Employee Id")]
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayName("Check In Time")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime CheckInTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayName("Check Out Time")]
        public DateTime CheckOutTime { get; set; }

        public Employee? Employee { get; set; }
        
    }
}
