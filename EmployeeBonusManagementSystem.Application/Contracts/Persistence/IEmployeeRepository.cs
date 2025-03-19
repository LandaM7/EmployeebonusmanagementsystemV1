namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence;

public interface IEmployeeRepository
{
    Task<(bool, int)> GetEmployeeExistsByPersonalNumberAsync(string personalNumber);
}



