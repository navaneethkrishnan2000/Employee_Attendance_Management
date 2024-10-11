using EmployeeAttendanceManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendanceManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendences { get; set; }

        // defines relationship between Employee and Attendance tables.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>() // Configure the Attendance entity
                .HasOne(a => a.Employee) // Each Attendance has one employee
                .WithMany(e => e.Attendances) // Each Ecployee has many Attendances
                .HasForeignKey(a => a.EmployeeId) // The foreign key is EmployeeId
                .OnDelete(DeleteBehavior.Cascade); // Deleting an Employee will delete related Attendance records
        }

    }
}
