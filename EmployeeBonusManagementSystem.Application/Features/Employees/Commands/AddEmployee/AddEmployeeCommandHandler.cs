using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Features.Employees.Commands;
using EmployeeBonusManagementSystem.Domain.Entities;
using EmployeeBonusManagementSystem.Persistence;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;


namespace EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee
{
	public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, bool>
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IJwtService _jwtService;

		public AddEmployeeCommandHandler(
			IEmployeeRepository employeeRepository,
			IUnitOfWork unitOfWork,
			IMapper mapper,
			IJwtService jwtService)
		{
			_employeeRepository = employeeRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_jwtService = jwtService;
		}

		public async Task<bool> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
		{
			try
			{
				// Log the start of the handler processing
				Console.WriteLine($"[INFO] Handling AddEmployeeCommand for Employee: {request.EmployeeDto.FirstName}");

				// Map EmployeeDto to EmployeeEntity
				var employee = _mapper.Map<EmployeeEntity>(request.EmployeeDto);
				Console.WriteLine($"UserName after mapping: {employee.UserName}"); // Add this line

				Console.WriteLine($"[INFO] Mapped EmployeeDto to EmployeeEntity successfully.");

				// Hash the password and generate the refresh token
				var hasher = new PasswordHasher<EmployeeEntity>();
				employee.Password = hasher.HashPassword(null, request.EmployeeDto.Password);

				Console.WriteLine($"[INFO] Password hashed for Employee: {request.EmployeeDto.FirstName}");

				employee.RefreshToken = _jwtService.GenerateRefreshToken();
				Console.WriteLine($"[INFO] Generated refresh token for Employee: {request.EmployeeDto.FirstName}");
				
				Console.WriteLine($"CreateDate before mapping: {employee.CreateDate}"); // Add this line

				employee.CreateDate = DateTime.UtcNow;
				Console.WriteLine($"CreateDate after mapping: {employee.CreateDate}"); // Add this line

				employee.PasswordChangeDate = DateTime.UtcNow;

				// Add the employee to the repository
				await _employeeRepository.AddEmployeeAsync(employee , request.EmployeeDto.Role );
				Console.WriteLine($"[INFO] Employee added to repository: {request.EmployeeDto.FirstName}");

				// Complete the transaction
				var saveResult = await _unitOfWork.CompleteAsync();
				if (saveResult > 0)
				{
					Console.WriteLine($"[INFO] Employee saved successfully in database: {request.EmployeeDto.FirstName}");
					return true;
				}
				// Log warning if save fails
				Console.WriteLine($"[WARN] Failed to save Employee: {request.EmployeeDto.FirstName} in database.");
				return false;
			}
			catch (Exception ex)
			{
				// Log the exception details
				Console.WriteLine($"[ERROR] Error occurred while handling AddEmployeeCommand for Employee: {request.EmployeeDto.FirstName}. Exception: {ex.Message}");
				return false;
			}
		}
	}
}
