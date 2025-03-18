using ManageEmployeesNet8.Enum;
using System.ComponentModel.DataAnnotations;

namespace ManageEmployeesNet8.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(8)]
        public string? Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public DateOnly Birthdate { get; set; }

        [Required]
        [StringLength(10)]
        public string Dni { get; set; }

        [StringLength(180)]
        public string? Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Department { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public HiringType HiringType { get; set; }

        [Required]
        public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
