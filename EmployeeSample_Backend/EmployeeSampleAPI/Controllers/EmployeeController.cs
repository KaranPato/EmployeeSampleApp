using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeSampleAPI.Model;

namespace EmployeeSampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAPI _employeeAPI;
        public EmployeeController(IEmployeeAPI employeeAPI)
        {
            _employeeAPI = employeeAPI;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeAPI.GetEmployees());
        }

        [HttpGet("GetManagers")]
        public IActionResult GetManagers()
        {
            return Ok(_employeeAPI.GetManagers());
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] List<Employee> Employee)
        {
            return Ok(_employeeAPI.AddEmployee(Employee));
        }

    }
}
