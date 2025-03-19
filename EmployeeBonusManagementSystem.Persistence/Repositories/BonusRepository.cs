﻿using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence.Common;
using EmployeeBonusManagementSystem.Application.Features.Bonuses.Commands.AddBonuses;
using EmployeeBonusManagementSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeBonusManagementSystem.Persistence.Repositories;

public class BonusRepository(
        ISqlQueryRepository sqlQueryRepository,
        ISqlCommandRepository sqlCommandRepository,
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
            var result = await sqlQueryRepository.LoadData<AddBonusesDto, dynamic>(
                "[HRManagementEmployee].[dbo].[ProcessRecommenderBonus]",
                new { EmployeeId = employeeId, BonusAmount = bonusAmount },
                configuration.GetConnectionString("DefaultConnection"),
                CommandType.StoredProcedure);

            return result.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}

