using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee;
using EmployeeBonusManagementSystem.Domain.Entities;

namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence;

public interface IEmployeeRepository
{
    Task<bool> ExistsByPersonalNumberAsync(string personalNumber);
    Task<bool> ExistsByEmailAsync(string email);
    Task AddEmployeeAsync(EmployeeEntity employee);
    Task<IEnumerable<EmployeeEntity>> GetAllAsync();

}



