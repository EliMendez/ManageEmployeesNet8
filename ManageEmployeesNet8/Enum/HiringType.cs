using System.ComponentModel.DataAnnotations;

namespace ManageEmployeesNet8.Enum
{
    public enum HiringType
    {
        [Display(Name = "Asalariado")]
        Salaried,

        [Display(Name = "Servicios profesionales")]
        ProfessionalFees
    }
}
