using AutoMapper;
using ManageEmployeesNet8.Models;
using ManageEmployeesNet8.Models.Dto;

namespace ManageEmployeesNet8.Mapper
{
    public class ManageEmployeeMapper: Profile
    {
        public ManageEmployeeMapper()
        {
            //Employee
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();

            //Payroll
            CreateMap<Payroll, PayrollDto>().ReverseMap();
            CreateMap<Payroll, CreatePayrollDto>().ReverseMap();

            //PayrollDetail
            CreateMap<PayrollDetail, PayrollDetailDto>().ReverseMap();
            CreateMap<PayrollDetail, CreatePayrollDetailDto>().ReverseMap();
        }
    }
}
