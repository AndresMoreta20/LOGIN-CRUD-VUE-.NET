using Microsoft.EntityFrameworkCore;

namespace CRUD_2.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> EmplloyeeItems { get; set; } = null!;
    }
}
