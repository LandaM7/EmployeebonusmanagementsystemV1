using EmployeeBonusManagementSystem.Application.Contracts.Persistence;

using MediatR;

namespace EmployeeBonusManagementSystem.Application.Features.Reports.Queries.GetTenEmployeeByBonuses;

internal class GetTenEmployeeByBonusesQueryHandler(
    IReportRepository reportRepository)
    : IRequestHandler<GetTenEmployeeByBonusesQuery, List<EmployeeBonusesDto>>
{
    public async Task<List<EmployeeBonusesDto>> Handle(
        GetTenEmployeeByBonusesQuery request,
        CancellationToken cancellationToken)
    {
        var result = await reportRepository.GetTenEmployeeByBonusesAsync(request.StartDate, request.EndDate);
        return result;
    }
}

