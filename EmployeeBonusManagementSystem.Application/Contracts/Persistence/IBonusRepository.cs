using EmployeeBonusManagementSystem.Domain.Entities;

namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence;

public interface IBonusRepository
{
    Task<int> AddBonusAsync(BonusEntity bonus);
    Task AddRecommenderBonusAsync(int employeeId, decimal bonusAmount);
}
