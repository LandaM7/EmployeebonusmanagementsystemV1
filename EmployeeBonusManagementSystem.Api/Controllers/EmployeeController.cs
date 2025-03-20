﻿using EmployeeBonusManagement.Application.Services;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Features.Employees.Common;
using EmployeeBonusManagementSystem.Application.Features.Employees.Queries;
using EmployeeBonusManagementSystem.Application.Features.Employees;
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee;
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.Login;
using EmployeeBonusManagementSystem.Application.Features.Employees.Queries.GetEmployeeBonus;
using EmployeeBonusManagementSystem.Application.Features.Employees.Queries.GetEmployeeSalary;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
	    [Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAllEmployees()
	    {
		    var employees = await _mediator.Send(new GetAllEmployeesQuery());
		    return Ok(employees);
	    }

		[HttpPost("addEmployee")]
	    [Authorize(Roles = "Admin")] 
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

	    [Authorize("User")]
		[HttpGet("GetEmployeeBonus")]
	    public async Task<ActionResult<List<GetEmployeeBonusDto>>> GetEmoloyeeBonus(
		    [FromQuery] GetEmployeeBonusQuery request)
	    {
		    var result = await _mediator.Send(request);
		    return Ok(result);
	    }

		[Authorize("User")]
	    [HttpGet("GetEmployeeSalary")]
	    public async Task<ActionResult<List<GetEmployeeBonusDto>>> GetEmoloyeeSalary(
		    [FromQuery] GetEmployeeSalaryQuery request)
	    {
		    var result = await _mediator.Send(request);
		    return Ok(result);
	    }

	}
}
