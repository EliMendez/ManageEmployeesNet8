using ManageEmployeesNet8.Enum;
using ManageEmployeesNet8.Models;

namespace ManageEmployeesNet8.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetEmployees();
        Task<ICollection<Employee>> GetEmployeesByHiringType(HiringType Type, DateTime PayrollEndDate);
        Task<Employee> GetEmployeeById(int EmployeeId);
        Task<bool> CreateEmployee(Employee Employee);
        Task<bool> UpdateEmployee(Employee Employee);
        Task<bool> DeleteEmployee(Employee Employee);
        Task<bool> SaveAsync();
    }
}
