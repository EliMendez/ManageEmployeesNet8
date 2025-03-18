using System.ComponentModel.DataAnnotations;

namespace ManageEmployeesNet8.Models.Dto
{
    public class CreatePayrollDetailDto
    {
        [Required]
        public int PayrollId { get; set; } // Clave foránea a la tabla Planilla

        [Required]
        public int EmployeeId { get; set; } // Clave foránea a la tabla Empleado

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public decimal BaseSalary { get; set; }

        public decimal? ISSS { get; set; }

        public decimal? AFP { get; set; }

        [Required]
        public decimal Rent { get; set; }

        [Required]
        public decimal NetSalary { get; set; }

        public Payroll Payroll { get; set; }
        public Employee Employee { get; set; }
    }
}
