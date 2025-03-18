﻿using AutoMapper;
using ManageEmployeesNet8.Models.Dto;
using ManageEmployeesNet8.Models;
using ManageEmployeesNet8.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ManageEmployeesNet8.Controllers
{
    [Route("/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _emRepo;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository emRepo, IMapper mapper)
        {
            _emRepo = emRepo;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return View(await _emRepo.GetEmployees());
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateEmployeeDto employeeDto)
        {

            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(employeeDto);
                await _emRepo.CreateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }

            //If the model is not valid, the view is returned with the errors.
            return View(employeeDto);

        }
    }
}
