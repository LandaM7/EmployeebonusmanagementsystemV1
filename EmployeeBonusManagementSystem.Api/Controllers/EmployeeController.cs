//using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee;
//using Microsoft.AspNetCore.Mvc;

//namespace EmployeeBonusManagementSystem.Api.Controllers
//{
//    [ApiController]
//    [Route("api/employees")]
//    public class EmployeeController : ControllerBase
//    {
//        private readonly EmployeeService _employeeService;

//        public EmployeeController(EmployeeService employeeService)
//        {
//            _employeeService = employeeService;
//        }


//        [HttpPost("Register")]
//        public async Task<IActionResult> RegisterEmployee([FromBody] EmployeeDto employeeDto)
//        {
//            if (employeeDto == null)
//                return BadRequest("Invalid employee data.");

//            try
//            {
//                bool isRegistered = await _employeeService.RegisterEmployeeAsync(employeeDto);
//                if (!isRegistered)
//                    return BadRequest("Employee registration failed.");

//                return Ok(new { message = "Employee registered successfully!" });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new { error = ex.Message });
//            }
//        }
//    }
//}
