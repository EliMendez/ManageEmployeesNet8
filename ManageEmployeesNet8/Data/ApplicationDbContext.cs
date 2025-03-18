using ManageEmployeesNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageEmployeesNet8.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Payroll> Payroll { get; set; }
        public DbSet<PayrollDetail> PayrollDetail { get; set; }
    }
}
