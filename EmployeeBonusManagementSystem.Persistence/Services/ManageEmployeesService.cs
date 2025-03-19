using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee;
using EmployeeBonusManagementSystem.Domain.Entities;
using EmployeeBonusManagementSystem.Persistence;
using Org.BouncyCastle.Crypto.Generators;
using Microsoft.AspNetCore.Identity;

namespace EmployeeBonusManagement.Application.Services
{
	public class ManageEmployeesService : IEmployeeService<EmployeeDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IJwtService _jwtService;
		private readonly IRoleAssignmentService _roleAssignmentService;
		private readonly IEmployeeRepository _employeeRepository;

		public ManageEmployeesService(
			IUnitOfWork unitOfWork,
			IMapper mapper,
			IJwtService jwtService,
			IRoleAssignmentService roleAssignmentService,
			IEmployeeRepository employeeRepository)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_jwtService = jwtService;
			_roleAssignmentService = roleAssignmentService;
			_employeeRepository = employeeRepository;
		}

		public async Task AddEmployeeAsync(EmployeeDto employeeDto)
		{
			try
			{
				var employee = _mapper.Map<EmployeeEntity>(employeeDto);

				var hasher = new PasswordHasher<object>();
				employee.Password = hasher.HashPassword(null, employeeDto.Password);


				//var refreshToken = _jwtService.GenerateRefreshToken();
				employee.RefreshToken = "";

				await _employeeRepository.AddEmployeeAsync(employee);

				// Assuming role assignment works with integer IDs now
				//await _roleAssignmentService.AssignRoleToUserAsync(employee.Id.ToString(), "User");
				//if (employeeDto.Role == Role.Admin.ToString())
				//{
				//	await _roleAssignmentService.AssignRoleToUserAsync(employee.Id.ToString(), "Admin");
				//}

				var saveResult = await _unitOfWork.CompleteAsync();
				Console.WriteLine($"CompleteAsync result: {saveResult}");

				if (saveResult <= 0)
				{
					Console.WriteLine("CompleteAsync returned 0, employee might not have been saved.");
				}
				else
				{
					Console.WriteLine("Employee added successfully.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error saving employee: {ex.Message}");
				Console.WriteLine($"Exception details: {ex}");
			}
		}

		public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
		{
			var employees = await _employeeRepository.GetAllAsync();
			return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
		}

		//public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
		//{
		//	var employee = await _employeeRepository.GetByIdAsync(id);
		//	return _mapper.Map<EmployeeDto>(employee);
		//}
	}
}