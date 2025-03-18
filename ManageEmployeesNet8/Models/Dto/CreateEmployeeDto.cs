using ManageEmployeesNet8.Enum;
using System.ComponentModel.DataAnnotations;

namespace ManageEmployeesNet8.Models.Dto
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El número máximo de caracteres es de 50.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El número máximo de caracteres es de 50.")]
        public string Surname { get; set; }

        [StringLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string? Email { get; set; }

        [StringLength(8, ErrorMessage = "El número máximo de caracteres es de 8.")]
        public string? Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatorio.")]
        public DateOnly? Birthdate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required(ErrorMessage = "El dui es obligatorio.")]
        [StringLength(10, ErrorMessage = "El número máximo de caracteres es de 10.")]
        public string Dni { get; set; }

        [StringLength(180, ErrorMessage = "El número máximo de caracteres es de 180.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio.")]
        [StringLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "El puesto del empleado es obligatorio.")]
        [StringLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string Position { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser un valor positivo.")]
        [Required(ErrorMessage = "El salario es obligatorio.")]
        public decimal? Salary { get; set; }

        [Required(ErrorMessage = "La fecha de contratación es obligatorio.")]
        public DateTime? HireDate { get; set; } //Fecha de contratación

        [Required(ErrorMessage = "Debe seleccionar el tipo de contratación.")]
        public HiringType HiringType { get; set; }

        public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
    }
}
