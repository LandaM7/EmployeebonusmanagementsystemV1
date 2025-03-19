using EmployeeBonusManagementSystem.Application.Features.Bonuses.Commands.AddBonuses;
using EmployeeBonusManagementSystem.Domain.Entities;

namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence;

public interface IBonusRepository
{
    Task<int> AddBonusAsync(BonusEntity bonus);
    Task<List<AddBonusesDto>> AddRecommenderBonusAsync(int employeeId, decimal bonusAmount);
}
