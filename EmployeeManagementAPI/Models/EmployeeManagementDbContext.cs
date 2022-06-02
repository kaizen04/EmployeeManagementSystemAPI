using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Models
{
    public class EmployeeManagementDbContext : DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<SalaryReport> SalaryReports { get; set; }

    }
}
