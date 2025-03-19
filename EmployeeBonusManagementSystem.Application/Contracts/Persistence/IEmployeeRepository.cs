using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee;
using EmployeeBonusManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence;

public interface IEmployeeRepository
{
	Task<bool> ExistsByPersonalNumberAsync(string personalNumber);
	Task<bool> ExistsByEmailAsync(string email);
	Task AddEmployeeAsync(EmployeeEntity employee, string role , IDbTransaction transaction);
	Task<IEnumerable<EmployeeEntity>> GetAllEmployeesAsync();
	Task<EmployeeEntity> GetByEmailAsync(string email);
	Task<bool> CheckPasswordAsync(EmployeeEntity user, string enteredPassword);
	Task<List<string>> GetUserRolesAsync(int employeeId);

}



