using Dapper;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeBonusManagementSystem.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IConfiguration _configuration;

    public EmployeeRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private IDbConnection CreateConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }

    public async Task<bool> ExistsByPersonalNumberAsync(string personalNumber)
    {
        using var connection = CreateConnection();
        var query = "SELECT COUNT(1) FROM Employees WHERE PersonalNumber = @PersonalNumber";
        var count = await connection.ExecuteScalarAsync<int>(query, new { PersonalNumber = personalNumber });

        return count > 0;
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        using var connection = CreateConnection();
        var query = "SELECT COUNT(1) FROM Employees WHERE Email = @Email";
        var count = await connection.ExecuteScalarAsync<int>(query, new { Email = email });

        return count > 0;
    }

    public async Task AddEmployeeAsync(EmployeeEntity employee)
    {
        using var connection = CreateConnection();
        var query = @"
                INSERT INTO Employees 
                (FirstName, LastName, PersonalNumber, BirthDate, Email, Password, Salary, HireDate, DepartmentId,
                  RecommenderEmployeeId, IsActive, IsPasswordChanged, PasswordChangeDate)
                VALUES 
                (@FirstName, @LastName, @PersonalNumber, @BirthDate, @Email, @Password, @Salary, @HireDate, @DepartmentId, 
                  @RecommenderEmployeeId, @IsActive, @IsPasswordChanged, @PasswordChangeDate)";

        await connection.ExecuteAsync(query, employee);
    }
}

