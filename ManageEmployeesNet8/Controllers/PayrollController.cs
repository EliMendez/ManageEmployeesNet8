using AutoMapper;
using ManageEmployeesNet8.Models.Dto;
using ManageEmployeesNet8.Models;
using ManageEmployeesNet8.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ManageEmployeesNet8.Controllers
{
    [Route("/[controller]")]
    public class PayrollController : Controller
    {
        private readonly IPayrollRepository _paRepo;
        private readonly IEmployeeRepository _emRepo;
        private readonly IMapper _mapper;

        public PayrollController(IPayrollRepository paRepo, IEmployeeRepository emRepo, IMapper mapper)
        {
            _paRepo = paRepo;
            _emRepo = emRepo;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return View(await _paRepo.GetPayrolls());
        }
    }
}
