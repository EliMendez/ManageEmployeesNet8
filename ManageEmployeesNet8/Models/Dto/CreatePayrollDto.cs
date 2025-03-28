﻿using ManageEmployeesNet8.Enum;
using System.ComponentModel.DataAnnotations;

namespace ManageEmployeesNet8.Models.Dto
{
    public class CreatePayrollDto
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public Period Period { get; set; }

        [Required]
        public PayrollType PayrollType { get; set; }
    }
}
