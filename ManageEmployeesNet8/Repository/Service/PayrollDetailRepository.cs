using EmployeeNet8.Repository.Interface;
using ManageEmployeesNet8.Data;
using ManageEmployeesNet8.Enum;
using ManageEmployeesNet8.Models;
using ManageEmployeesNet8.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ManageEmployeesNet8.Repository.Service
{
    public class PayrollDetailRepository : IPayrollDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public PayrollDetailRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreatePayrollDetail(PayrollDetail PayrollDetail)
        {
            PayrollDetail.CreatedDate = DateTime.Now;
            _db.PayrollDetail.Add(PayrollDetail);

            return await SaveAsync();
        }

        public async Task<bool> DeletePayrollDetail(PayrollDetail PayrollDetail)
        {
            _db.PayrollDetail.Remove(PayrollDetail);
            return await SaveAsync();
        }

        public async Task<ICollection<PayrollDetail>> GetPayrollDetails(int payrollId)
        {
            return await _db.PayrollDetail.Where(p => p.PayrollId == payrollId).OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePayrollDetail(PayrollDetail PayrollDetail)
        {
            PayrollDetail.UpdatedDate = DateTime.Now;
            _db.PayrollDetail.Update(PayrollDetail);

            return await SaveAsync();
        }
    }
}
