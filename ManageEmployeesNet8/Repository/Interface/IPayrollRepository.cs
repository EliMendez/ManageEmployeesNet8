using ManageEmployeesNet8.Enum;
using ManageEmployeesNet8.Models;

namespace ManageEmployeesNet8.Repository.Interface
{
    public interface IPayrollRepository
    {
        Task<ICollection<Payroll>> GetPayrolls();
        Task<Payroll> GetPayrollById(int PayrollId);
        Task<Payroll> CreatePayroll(Payroll Payroll);
        Task<Payroll> UpdatePayroll(Payroll Payroll);
        Task<bool> DeletePayroll(Payroll Payroll);
        Task<bool> SaveAsync();
    }
}
