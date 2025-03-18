using ManageEmployeesNet8.Models;

namespace EmployeeNet8.Repository.Interface
{
    public interface IPayrollDetailRepository
    {
        Task<ICollection<PayrollDetail>> GetPayrollDetails(int payrollId);
        Task<bool> CreatePayrollDetail(PayrollDetail PayrollDetail);
        Task<bool> UpdatePayrollDetail(PayrollDetail PayrollDetail);
        Task<bool> DeletePayrollDetail(PayrollDetail PayrollDetail);
        Task<bool> SaveAsync();
    }
}
