using AutoMapper;
using ManageEmployeesNet8.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ManageEmployeesNet8.Controllers
{
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
    }
}
