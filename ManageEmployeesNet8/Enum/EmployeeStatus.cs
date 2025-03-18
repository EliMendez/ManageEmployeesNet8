using System.ComponentModel.DataAnnotations;

namespace ManageEmployeesNet8.Enum
{
    public enum EmployeeStatus
    {
        [Display(Name = "Activo")]
        Active,

        [Display(Name = "No activo")]
        NoActive
    }
}
