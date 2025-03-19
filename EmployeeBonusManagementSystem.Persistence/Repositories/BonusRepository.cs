using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence.Common;
using EmployeeBonusManagementSystem.Application.Features.Bonuses.Commands.AddBonuses;
using EmployeeBonusManagementSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;

namespace EmployeeBonusManagementSystem.Persistence.Repositories;

public class BonusRepository(
        ISqlQueryRepository sqlQueryRepository,
        ISqlCommandRepository sqlCommandRepository,
        IUnitOfWork unitOfWork,
        IConfiguration configuration)
        : IBonusRepository

{
    public async Task<int> AddBonusAsync(BonusEntity bonus)
    {
        try
        {
            var query = @"
            INSERT INTO [HRManagementEmployee].[dbo].[Bonuses]
                (EmployeeId, Amount, IsRecommenderBonus, Reason, CreateDate, CreateByUserId, RecommendationLevel)
            VALUES
               (@EmployeeId, @Amount, @IsRecommenderBonus, @Reason, @CreateDate, @CreateByUserId, @RecommendationLevel);            
            SELECT SCOPE_IDENTITY();
        ";
            var parameters = new
            {
                EmployeeId = bonus.EmployeeId,
                Amount = bonus.Amount,
                IsRecommenderBonus = bonus.IsRecommenderBonus,
                Reason = bonus.Reason,
                CreateDate = bonus.CreateDate,
                CreateByUserId = bonus.CreateByUserId,
                RecommendationLevel = bonus.RecommendationLevel
            };


            return await sqlCommandRepository.SaveData(
                query,
                parameters,
                configuration.GetConnectionString("DefaultConnection"),
                CommandType.Text);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
    public async Task<List<AddBonusesDto>> AddRecommenderBonusAsync(int employeeId, decimal bonusAmount)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();

            var result = await sqlQueryRepository.LoadData<AddBonusesDto, dynamic>(
                "[HRManagementEmployee].[dbo].[AddBonuses]",
                new { EmployeeId = employeeId, BonusAmount = bonusAmount },
                configuration.GetConnectionString("DefaultConnection"),
                CommandType.StoredProcedure);

            await unitOfWork.CommitAsync();
            return result.ToList();

        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();
            throw new Exception(ex.Message);
    }
}

}
