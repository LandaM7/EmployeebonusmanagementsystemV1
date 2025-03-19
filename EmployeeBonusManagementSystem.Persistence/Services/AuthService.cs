using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeBonusManagement.Application.Services.Interfaces;
using EmployeeBonusManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeBonusManagement.Application.Services
{
	public class AuthService : IAuthService
	{

		//private readonly IEmployeeRepository<EmployeeEntity> _employeeRepository; // Change to ApplicationUser
		//private readonly IJwtService _jwtService;

		//public AuthService(IEmployeeRepository<EmployeeEntity> employeeRepository, IJwtService jwtService)
		//{
		//	_employeeRepository = employeeRepository;
		//	_jwtService = jwtService;
		//}

		//public async Task<AuthResponse> LoginAsync(LoginDto loginDto)
		//{
		//	Console.WriteLine($"Attempting login for email: {loginDto.Email}");
		//	var user = await _employeeRepository.GetUserByEmailAsync(loginDto.Email.ToLower());
		//	if (user == null)
		//	{
		//		Console.WriteLine("User not found");
		//		return new AuthResponse(false) { Success = false };
		//	}

		//	Console.WriteLine("User Found");

		//	if (!await _employeeRepository.CheckPasswordAsync(user, loginDto.Password))
		//	{
		//		Console.WriteLine("Incorrect password");
		//		return new AuthResponse(false) { Success = false };
		//	}

		//	Console.WriteLine("Password Correct");

		//	var roles = await _employeeRepository.GetUserRolesAsync(user);
		//	var token = _jwtService.GenerateToken(user, roles);

		//	if (token == null || string.IsNullOrEmpty(token.AccessToken))
		//	{
		//		Console.WriteLine("Token generation failed");
		//	}

		//	return new AuthResponse(true)
		//	{
		//		AccessToken = token.AccessToken,
		//		RefreshToken = token.RefreshToken,
		//		Expiration = token.Expiration,
		//		UserEmail = user.Email,
		//		Roles = roles.ToList(),
		//		Success = true
		//	};
		//}
	}

}