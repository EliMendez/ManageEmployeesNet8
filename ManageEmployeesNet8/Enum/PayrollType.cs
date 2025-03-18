using System.ComponentModel.DataAnnotations;

namespace ManageEmployeesNet8.Enum
{
    public enum PayrollType
    {
        [Display(Name = "Planilla de honorarios")]
        PayrollForFees,

        [Display(Name = "Planilla de sueldos")]
        Payroll
    }
}
