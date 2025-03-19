using EmployeeBonusManagementSystem.Domain.Entities;

namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence;

public interface IEmployeeRepository
{
    Task<EmployeeEntity?> GetByPersonalNumberAsync(string personalNumber);
}



