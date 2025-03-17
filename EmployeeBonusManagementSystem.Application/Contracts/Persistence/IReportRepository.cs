using EmployeeBonusManagementSystem.Application.DTO;
using EmployeeBonusManagementSystem.Application.Features.Reports.Queries.GetTotalBonuses;

namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence;
public interface IReportRepository
{
    Task<TotalBonusesDto> GetTotalBonusesAsync(DateTime startDate, DateTime endDate);
    Task<List<EmployeeBonusDto>> GetTop10EmployeesByBonusAsync(DateTime startDate, DateTime endDate);
    Task<List<EmployeeBonusDto>> GetTotalBonusesByDepartmentInLastMonthAsync(DateTime startDate, DateTime endDate);
    Task<List<EmployeeBonusDto>> GetTop10EmployeesByBonusInLastMonthAsync(DateTime startDate, DateTime endDate);
    Task<List<EmployeeBonusDto>> GetTop10EmployeesByBonusInLast3MonthAsync(DateTime startDate, DateTime endDate);
    Task<List<EmployeeBonusDto>> GetTop10EmployeesByBonusInLastYearAsync(DateTime startDate, DateTime endDate);
    Task<List<EmployeeBonusDto>> GetTop10EmployeesByTotalBonusAsync(DateTime startDate, DateTime endDate);
    Task<List<EmployeeBonusDto>> GetTop10RecommendersByBonusesInLastMonthAsync(DateTime startDate, DateTime endDate);
    Task<List<EmployeeBonusDto>> GetTop10RecommendersByBonusesInLast3MonthAsync(DateTime startDate, DateTime endDate);
}
