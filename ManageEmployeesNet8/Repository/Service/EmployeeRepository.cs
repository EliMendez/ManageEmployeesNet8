using ManageEmployeesNet8.Data;
using ManageEmployeesNet8.Enum;
using ManageEmployeesNet8.Models;
using ManageEmployeesNet8.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ManageEmployeesNet8.Repository.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateEmployee(Employee Employee)
        {
            Employee.CreatedDate = DateTime.Now;
            _db.Employee.Add(Employee);

            return await SaveAsync();
        }

        public async Task<bool> DeleteEmployee(Employee Employee)
        {
            _db.Employee.Remove(Employee);
            return await SaveAsync();
        }

        public async Task<Employee> GetEmployee(int EmployeeId)
        {
            return await _db.Employee.FirstOrDefaultAsync(e => e.Id == EmployeeId);
        }

        public async Task<ICollection<Employee>> GetEmployees()
        {
            return await _db.Employee.OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<ICollection<Employee>> GetEmployeesByHiringType(HiringType Type, DateTime PayrollEndDate)
        {
            return await _db.Employee.Where(e => e.HiringType.Equals(Type))
                .Where(e => e.HireDate <= PayrollEndDate)
                .Where(e => e.Status <= EmployeeStatus.Active)
                .ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateEmployee(Employee Employee)
        {
            Employee.UpdatedDate = DateTime.Now;
            _db.Employee.Update(Employee);

            return await SaveAsync();
        }
    }
}
