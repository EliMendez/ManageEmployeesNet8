using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ManageEmployeesNet8.Utils
{
    public class PayrollCalculator
    {
        private const decimal ISSS_PERCENTAGE = 0.03m;
        private const decimal AFP_PERCENTAGE = 0.0725m;
        private const decimal RENT_PERCENTAGE_PROFESSIONAL_FEES = 0.01m;

        public static decimal CalculateAFP(decimal salary) => salary * AFP_PERCENTAGE;

        public static decimal CalculateRentProfessionalFees(decimal salary) => salary * RENT_PERCENTAGE_PROFESSIONAL_FEES;

        public static decimal CalculateISSS(decimal salary)
        {
            decimal isss = 0;
            isss = salary * ISSS_PERCENTAGE;

            if (isss > 30)
            {
                isss = 30;
            }

            return isss;
        }

        public static decimal CalculateRent(decimal baseSalary, decimal isss, decimal afp)
        {
            // Lógica para calcular la renta
            decimal rent = 0;
            if ((baseSalary - isss - afp) < decimal.Parse("895.24"))
            {
                rent = ((((baseSalary - isss - afp) - decimal.Parse("472.00")) * decimal.Parse("0.1")) + decimal.Parse("17.67"));
            }
            else if ((baseSalary - isss - afp) < decimal.Parse("2038.10"))
            {
                rent = ((((baseSalary - isss - afp) - decimal.Parse("895.24")) * decimal.Parse("0.2")) + decimal.Parse("60.00"));
            }
            else
            {
                rent = ((((baseSalary - isss - afp) - decimal.Parse("2038.10")) * decimal.Parse("0.3")) + decimal.Parse("288.57"));
            }

            return rent;
        }
    }
}
