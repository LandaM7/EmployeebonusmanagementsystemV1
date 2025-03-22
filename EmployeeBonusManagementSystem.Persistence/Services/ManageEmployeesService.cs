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
using EmployeeBonusManagementSystem.Application.Features.Employees.Common;

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


		public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
		{
			var employees = await _employeeRepository.GetAllEmployeesAsync();
			return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
		}

		//public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
		//{
		//	var employee = await _employeeRepository.GetByIdAsync(id);
		//	return _mapper.Map<EmployeeDto>(employee);
		//}
	}
}