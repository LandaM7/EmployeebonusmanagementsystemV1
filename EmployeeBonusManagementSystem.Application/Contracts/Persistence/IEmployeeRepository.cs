using EmployeeBonusManagementSystem.Application.Features.Employees.Commands.AddEmployee;
using EmployeeBonusManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence;

public interface IEmployeeRepository
{
    Task<bool> ExistsByPersonalNumberAsync(string personalNumber);
    Task<bool> ExistsByEmailAsync(string email);

}



