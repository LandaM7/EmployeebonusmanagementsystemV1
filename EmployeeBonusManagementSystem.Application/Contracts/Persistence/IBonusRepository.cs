using EmployeeBonusManagementSystem.Application.Features.Bonuses.Commands.AddBonuses;
using EmployeeBonusManagementSystem.Domain.Entities;

namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence;

public interface IBonusRepository
{
    public Task<List<AddBonusesDto>> AddBonusAsync(BonusEntity bonus);

}
