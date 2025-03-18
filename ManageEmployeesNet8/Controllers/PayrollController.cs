﻿using AutoMapper;
using ManageEmployeesNet8.Models.Dto;
using ManageEmployeesNet8.Models;
using ManageEmployeesNet8.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using ManageEmployeesNet8.Enum;
using ManageEmployeesNet8.Utils;
using EmployeeNet8.Repository.Interface;

namespace ManageEmployeesNet8.Controllers
{
    [Route("/[controller]")]
    public class PayrollController : Controller
    {
        private readonly IPayrollRepository _paRepo;
        private readonly IPayrollDetailRepository _pdRepo;
        private readonly IEmployeeRepository _emRepo;
        private readonly IMapper _mapper;

        public PayrollController(IPayrollRepository paRepo, IPayrollDetailRepository pdRepo, IEmployeeRepository emRepo, IMapper mapper)
        {
            _paRepo = paRepo;
            _pdRepo = pdRepo;
            _emRepo = emRepo;
            _mapper = mapper;
        }


        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return View(await _paRepo.GetPayrolls());
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreatePayrollDto payrollDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Calcular EndDate
                    payrollDto.EndDate = CalculateEndDate(payrollDto.StartDate, payrollDto.EndDate, payrollDto.Period);

                    var payroll = _mapper.Map<Payroll>(payrollDto);
                    var payrollCreated = await _paRepo.CreatePayroll(payroll);

                    ICollection<Employee> employees;
                    if (payroll.PayrollType == PayrollType.Payroll)
                    {
                        employees = await _emRepo.GetEmployeesByHiringType(HiringType.Salaried, payroll.EndDate);
                        await ProcessPayrollDetails(payrollCreated, employees, false);
                    }
                    else
                    {
                        employees = await _emRepo.GetEmployeesByHiringType(HiringType.ProfessionalFees, payroll.EndDate);
                        await ProcessPayrollDetails(payrollCreated, employees, true);
                    }

                    return RedirectToAction(nameof(Index));
                }

                return View(payrollDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al crear la planilla: " + ex.Message);
                return View(payrollDto);
            }
        }

        private DateTime CalculateEndDate(DateTime startDate, DateTime endDate, Period period)
        {
            if (period == Period.Monthly)
            {
                // Obtener el último día del mes para la fecha de inicio
                endDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month));
            }
            else if (period == Period.Biweekly)
            {
                if (startDate.Day == 16)
                {
                    if (startDate.Month == 1 || startDate.Month == 3 || startDate.Month == 5 || startDate.Month == 7 || startDate.Month == 8 || startDate.Month == 10 || startDate.Month == 12)
                    {
                        endDate = startDate.AddDays(15);
                    }
                    else if (startDate.Month == 2)
                    {
                        endDate = startDate.AddDays(12);
                    }
                    else
                    {
                        endDate = startDate.AddDays(14);
                    }
                }
                else
                {
                    endDate = startDate.AddDays(14);
                }
            }

            return endDate;
        }

        private (decimal isss, decimal afp, decimal rent, decimal netSalary) CalculatePayrollValues(decimal baseSalary, PayrollType payrollType)
        {
            decimal isss = 0, afp = 0, rent;

            if (payrollType == PayrollType.Payroll)
            {
                isss = PayrollCalculator.CalculateISSS(baseSalary);
                afp = PayrollCalculator.CalculateAFP(baseSalary);
                rent = PayrollCalculator.CalculateRent(baseSalary, isss, afp);
            }
            else
            {
                rent = PayrollCalculator.CalculateRentProfessionalFees(baseSalary);
            }

            var netSalary = baseSalary - isss - afp - rent;
            return (isss, afp, rent, netSalary);
        }

        private async Task ProcessPayrollDetails(Payroll payrollCreated, ICollection<Employee> employees, bool isProfessionalFees)
        {
            foreach (var employee in employees)
            {
                var baseSalary = employee.Salary;
                var (isss, afp, rent, netSalary) = CalculatePayrollValues(baseSalary, payrollCreated.PayrollType);

                var newPayrollDetail = CreatePayrollDetail(payrollCreated, employee, baseSalary, isss, afp, rent, netSalary);
                await _pdRepo.CreatePayrollDetail(newPayrollDetail);
            }
        }

        private PayrollDetail CreatePayrollDetail(Payroll payroll, Employee employee, decimal baseSalary, decimal isss, decimal afp, decimal rent, decimal netSalary)
        {
            return new PayrollDetail
            {
                PayrollId = payroll.Id,
                EmployeeId = employee.Id,
                Payroll = payroll,
                Employee = employee,
                Name = employee.Name,
                Surname = employee.Surname,
                BaseSalary = baseSalary,
                ISSS = isss,
                AFP = afp,
                Rent = rent,
                NetSalary = netSalary,
            };
        }
    }
}
