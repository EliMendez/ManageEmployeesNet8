using AutoMapper;
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

        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            Employee employee = await _emRepo.GetEmployeeById(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return View(employeeDto);
        }

        [HttpPost("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id, EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(employeeDto);
                await _emRepo.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }

            //If the model is not valid, the view is returned with the errors.
            return View(employeeDto);
        }

        [HttpPost("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var employee = await _emRepo.GetEmployeeById(id);
                await _emRepo.DeleteEmployee(employee);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
