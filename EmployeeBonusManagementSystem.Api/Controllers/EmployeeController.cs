using EmployeeBonusManagement.Application.Services;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Features.Employees.Common;
using EmployeeBonusManagementSystem.Application.Features.Employees.Queries;
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands;
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee;
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBonusManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
	    private readonly IMediator _mediator;

	    public EmployeeController(IMediator mediator)
	    {
		    _mediator = mediator;
	    }

	    [HttpGet]
	    public async Task<IActionResult> GetAllEmployees()
	    {
		    var employees = await _mediator.Send(new GetAllEmployeesQuery());
		    return Ok(employees);
	    }

	    [HttpPost("addEmployee")]
		public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employeeDto)
	    {
		    var result = await _mediator.Send(new AddEmployeeCommand(employeeDto));

		    if (result)
		    {
			    return Ok(new { message = "Employee added successfully" });
		    }
		    return BadRequest(new { message = "Failed to add employee" });
	    }

	    [HttpPost("login")]
	    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
	    {
		    var result = await _mediator.Send(new LoginCommand(loginDto));

		    if (result.Success)
			    return Ok(result);

		    return Unauthorized(new { message = "Invalid credentials" });
	    }


	}
}
