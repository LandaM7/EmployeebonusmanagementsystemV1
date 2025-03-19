using EmployeeBonusManagement.Application.Services;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBonusManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
	    private readonly IEmployeeService<EmployeeDto> _employeeService;

		public EmployeeController(IEmployeeService<EmployeeDto> employeeService)
        {
            _employeeService = employeeService;
        }


		//[HttpPost("Register")]
		//public async Task<IActionResult> RegisterEmployee([FromBody] EmployeeDto employeeDto)
		//{
		//    if (employeeDto == null)
		//        return BadRequest("Invalid employee data.");

		//    try
		//    {
		//        bool isRegistered = await _employeeService.RegisterEmployeeAsync(employeeDto);
		//        if (!isRegistered)
		//            return BadRequest("Employee registration failed.");

		//        return Ok(new { message = "Employee registered successfully!" });
		//    }
		//    catch (Exception ex)
		//    {
		//        return StatusCode(500, new { error = ex.Message });
		//    }
		//}

		[HttpGet]
		public async Task<IActionResult> GetAllEmployees()
		{
			var employees = await _employeeService.GetAllEmployeesAsync();
			return Ok(employees);
		}

		[HttpPost("add")]
		public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employee)
		{
			await _employeeService.AddEmployeeAsync(employee);
			return Ok("Employee added successfully!");
		}


	}
}
