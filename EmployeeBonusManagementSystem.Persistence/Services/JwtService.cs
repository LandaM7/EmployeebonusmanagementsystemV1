using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EmployeeBonusManagement.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeBonusManagement.Application.Services
{
    public class JwtService : IJwtService
    {
		private readonly IConfiguration _config;

		public JwtService(IConfiguration config)
		{
			_config = config;
		}


		//public AuthResponse GenerateToken(ApplicationUser user, IList<string> roles)
		//{
		//	try
		//	{
		//		Console.WriteLine("Generating JWT Token...");
		//		//Console.WriteLine(GenerateJwtSecretKey());

		//		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
		//		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		//		var claims = new List<Claim>
		//{
		//	new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
		//	new Claim(ClaimTypes.Email, user.Email)
		//};


		//		// Add roles as claims
		//		if (roles != null && roles.Any())
		//		{
		//			Console.WriteLine($"Adding roles: {string.Join(", ", roles)}");
		//			claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
		//		}
		//		else
		//		{
		//			Console.WriteLine("No roles found for user.");
		//		}

		//		var token = new JwtSecurityToken(
		//			issuer: _config["Jwt:Issuer"],
		//			audience: _config["Jwt:Audience"],
		//			claims: claims,
		//			expires: DateTime.UtcNow.AddHours(1), // Token expiration
		//			signingCredentials: creds
		//		);

		//		string accessToken = new JwtSecurityTokenHandler().WriteToken(token);
		//		string refreshToken = GenerateRefreshToken();

		//		var authResponse = new AuthResponse(
		//			success: true,
		//			accessToken: accessToken,
		//			refreshToken: refreshToken,
		//			expiration: token.ValidTo,
		//			userEmail: user.Email,
		//			roles: roles.ToList()
		//		);

		//		Console.WriteLine("JWT Token generated successfully.");
		//		return authResponse;
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine($"Error generating token: {ex.Message}");
		//		Console.WriteLine($"Exception details: {ex}"); // Log the full exception

		//		return new AuthResponse(false)
		//		{
		//			Success = false
		//		};
		//	}
		//}

		//public  string GenerateRefreshToken()
		//{
		//	return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
		//}
	}
}
