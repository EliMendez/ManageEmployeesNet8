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

            //Employee
            CreateMap<Payroll, PayrollDto>().ReverseMap();
            CreateMap<Payroll, CreatePayrollDto>().ReverseMap();
        }
    }
}
