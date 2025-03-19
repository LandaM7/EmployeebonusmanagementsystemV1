using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence.Common;
using EmployeeBonusManagementSystem.Domain.Entities;
using System.Data;
namespace EmployeeBonusManagementSystem.Persistence.Repositories.Implementations
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly IDbConnection _connection;
		private readonly IDbTransaction _transaction;

		public EmployeeRepository(IDbConnection connection, IDbTransaction transaction)
		{
			_connection = connection;
			_transaction = transaction;
		}
    }
		public async Task<bool> ExistsByPersonalNumberAsync(string personalNumber)
		{
			var query = "SELECT COUNT(1) FROM Employees WHERE PersonalNumber = @PersonalNumber";
			var count = await _connection.ExecuteScalarAsync<int>(query, new { PersonalNumber = personalNumber }, _transaction);
			return count > 0;
		}

		public async Task<bool> ExistsByEmailAsync(string email)
		{
			var query = "SELECT COUNT(1) FROM Employees WHERE Email = @Email";
			var count = await _connection.ExecuteScalarAsync<int>(query, new { Email = email }, _transaction);
			return count > 0;
		}

		public async Task AddEmployeeAsync(EmployeeEntity employee)
		{
			var query = @"
                INSERT INTO Employees (FirstName, LastName, PersonalNumber, BirthDate, Email, Password, Salary, HireDate, DepartmentId, RecommenderEmployeeId, IsActive, IsPasswordChanged, PasswordChangeDate)
                VALUES (@FirstName, @LastName, @PersonalNumber, @BirthDate, @Email, @Password, @Salary, @HireDate, @DepartmentId, @RecommenderEmployeeId, @IsActive, @IsPasswordChanged, @PasswordChangeDate)";
			await _connection.ExecuteAsync(query, employee, _transaction);
		}

		public async Task<EmployeeEntity> GetByIdAsync(int id)
		{
			var query = "SELECT * FROM Employees WHERE Id = @Id";
			return await _connection.QueryFirstOrDefaultAsync<EmployeeEntity>(query, new { Id = id }, _transaction);
		}

		public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
		{
			var query = "SELECT * FROM Employees";
			return await _connection.QueryAsync<EmployeeEntity>(query, transaction: _transaction);
		}

		public async Task UpdateAsync(EmployeeEntity employee)
		{
			var query = @"
                UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, PersonalNumber = @PersonalNumber, BirthDate = @BirthDate, Email = @Email, Password = @Password, Salary = @Salary, HireDate = @HireDate, DepartmentId = @DepartmentId, RecommenderEmployeeId = @RecommenderEmployeeId, IsActive = @IsActive, IsPasswordChanged = @IsPasswordChanged, PasswordChangeDate = @PasswordChangeDate
                WHERE Id = @Id";
			await _connection.ExecuteAsync(query, employee, _transaction);
		}

		public async Task DeleteAsync(EmployeeEntity employee)
		{
			var query = "DELETE FROM Employees WHERE Id = @Id";
			await _connection.ExecuteAsync(query, new { Id = employee.Id }, _transaction);
		}
	}
}
