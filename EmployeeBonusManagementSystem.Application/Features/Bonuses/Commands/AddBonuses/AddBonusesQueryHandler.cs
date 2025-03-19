using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Domain.Entities;
using EmployeeBonusManagementSystem.Persistence;
using MediatR;

namespace EmployeeBonusManagementSystem.Application.Features.Bonuses.Commands.AddBonuses;

public class AddBonusesQueryHandler(
    IBonusRepository bonusRepository,
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork
    /*JsonWebToken როლები*/)
    : IRequestHandler<AddBonusesQuery, List<AddBonusesDto>>
{
    public async Task<List<AddBonusesDto>> Handle(
        AddBonusesQuery request,
        CancellationToken cancellationToken)

    {
        // თანამშრომლის ნახვა PersonalNumber ით
        //var employee = await employeeRepository.GetByPersonalNumberAsync(request.PersonalNumber);
        //if (employee == null)
        //{
        //    throw new Exception($"თანამშრომელი პირადი ნომრით {request.PersonalNumber} არ მოიძებნა.");
        //}


        var mainBonus = new BonusEntity
        {
            //EmployeeId = employee.Id,
            Amount = request.BonusAmount,
            //Reason = reason,
            CreateDate = DateTime.UtcNow,
            IsRecommenderBonus = false,
            RecommendationLevel = 0,
            //CreateByUserId = adminUserId, ეს ჯერ არ მაქვს
        };
        //int adminUserId = currentUserService.GetUserId(); ეს JWT

    //    using (var transaction = await unitOfWork.BeginTransactionAsync())
    //    {
    //        try
    //        {

        //await unitOfWork.BeginTransactionAsync();
        try
        {
        //    await bonusRepository.AddBonusAsync(mainBonus);
        //    await bonusRepository.AddRecommenderBonusAsync(employee.Id, request.BonusAmount);
        //    await unitOfWork.CommitAsync();

            var bonuses = new List<AddBonusesDto>
            {
                new()
                {
                    EmployeeId = mainBonus.EmployeeId,
                    Amount = mainBonus.Amount,
                    Reason = mainBonus.Reason,
                    CreateDate = mainBonus.CreateDate,
                    RecommendationLevel = mainBonus.RecommendationLevel,
                    IsRecommenderBonus = mainBonus.IsRecommenderBonus
    }
            };

            return bonuses;
        }
        catch
        {
           // await unitOfWork.RollbackAsync();
            throw;
        }
    }
}
