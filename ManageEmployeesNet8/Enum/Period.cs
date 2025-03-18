using System.ComponentModel.DataAnnotations;

namespace ManageEmployeesNet8.Enum
{
    public enum Period
    {
        [Display(Name = "Mensual")]
        Monthly,

        [Display(Name = "Quincenal")]
        Biweekly
    }
}
