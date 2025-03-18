using ManageEmployeesNet8.Data;
using ManageEmployeesNet8.Enum;
using ManageEmployeesNet8.Models;
using ManageEmployeesNet8.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ManageEmployeesNet8.Repository.Service
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly ApplicationDbContext _db;

        public PayrollRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Payroll> CreatePayroll(Payroll Payroll)
        {
            Payroll.CreatedDate = DateTime.Now;
            _db.Payroll.Add(Payroll);
            await SaveAsync();

            return Payroll;
        }

        public async Task<bool> DeletePayroll(Payroll Payroll)
        {
            _db.Payroll.Remove(Payroll);
            return await SaveAsync();
        }

        public async Task<Payroll> GetPayrollById(int PayrollId)
        {
            return await _db.Payroll.FirstOrDefaultAsync(e => e.Id == PayrollId);
        }

        public async Task<ICollection<Payroll>> GetPayrolls()
        {
            return await _db.Payroll.OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Payroll> UpdatePayroll(Payroll Payroll)
        {
            Payroll.UpdatedDate = DateTime.Now;
            _db.Payroll.Update(Payroll);
            await SaveAsync();

            return Payroll;
        }
    }
}
