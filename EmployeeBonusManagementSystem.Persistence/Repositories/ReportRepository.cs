using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence.Common;
using EmployeeBonusManagementSystem.Application.DTO;
using EmployeeBonusManagementSystem.Application.Features.Reports.Queries.GetTotalBonuses;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeBonusManagementSystem.Infrastructure.Repositories
{
    public class ReportRepository(
        ISqlQueryRepository sqlQueryRepository,
        IConfiguration configuration)
        : IReportRepository
    {
        // ჯამურად გაცემული ბონუსების რაოდენობა მითითებულ თარიღებში     
        public async Task<TotalBonusesDto> GetTotalBonusesAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var query = @"
                    SELECT 
                        COUNT(*) AS TotalBonuses, 
                        SUM(Amount) AS TotalBonusAmount
                    FROM
                        Bonuses(NOLOCK)
                    WHERE
                        CreateDate BETWEEN @StartDate AND @EndDate;
                ";

                return await sqlQueryRepository.LoadDataFirstOrDefault<TotalBonusesDto, dynamic>(
                    query,
                    new { startDate, endDate },
                    configuration.GetConnectionString("DefaultConnection"),
                    CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // Top 10 თანამშრომელი, ვინც ყველაზე მეტი ბონუსი მიიღო მითითებულ თარიღებში     
        public async Task<List<EmployeeBonusDto>> GetTop10EmployeesByBonusAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await sqlQueryRepository.LoadData<EmployeeBonusDto, dynamic>(
                   "GetTop10EmployeesByBonusInLastMonth",
                   new { StartDate = startDate, EndDate = endDate },
                   configuration.GetConnectionString("DefaultConnection"),
                   CommandType.StoredProcedure);
                return result.ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// ჯამურად გაცემული ბონუსები დეპარტამენტების მიხედვით მითითებულ თარიღებში  
        public async Task<List<EmployeeBonusDto>> GetTotalBonusesByDepartmentInLastMonthAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await sqlQueryRepository.LoadData<EmployeeBonusDto, dynamic>(
                       "GetTotalBonusesByDepartmentInLastMonth",
                       new { StartDate = startDate, EndDate = endDate },
                       configuration.GetConnectionString("DefaultConnection"),
                       CommandType.StoredProcedure);
                return result.ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<EmployeeBonusDto>> GetTop10EmployeesByBonusInLastMonthAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await sqlQueryRepository.LoadData<EmployeeBonusDto, dynamic>(
                   "GetTop10EmployeesByBonusInLastMonth",
                   new { StartDate = startDate, EndDate = endDate },
                   configuration.GetConnectionString("DefaultConnection"),
                   CommandType.StoredProcedure);
                return result.ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<EmployeeBonusDto>> GetTop10EmployeesByBonusInLast3MonthAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await sqlQueryRepository.LoadData<EmployeeBonusDto, dynamic>(
                       "GetTop10EmployeesByBonusInLast3Month",
                       new { StartDate = startDate, EndDate = endDate },
                       configuration.GetConnectionString("DefaultConnection"),
                       CommandType.StoredProcedure);
                return result.ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EmployeeBonusDto>> GetTop10EmployeesByBonusInLastYearAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await sqlQueryRepository.LoadData<EmployeeBonusDto, dynamic>(
                   "GetTop10EmployeesByBonusInLastYear",
                   new { StartDate = startDate, EndDate = endDate },
                   configuration.GetConnectionString("DefaultConnection"),
                   CommandType.StoredProcedure);
                return result.ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EmployeeBonusDto>> GetTop10EmployeesByTotalBonusAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await sqlQueryRepository.LoadData<EmployeeBonusDto, dynamic>(
                       "GetTop10EmployeesByTotalBonus",
                       new { StartDate = startDate, EndDate = endDate },
                       configuration.GetConnectionString("DefaultConnection"),
                       CommandType.StoredProcedure);
                return result.ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EmployeeBonusDto>> GetTop10RecommendersByBonusesInLastMonthAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await sqlQueryRepository.LoadData<EmployeeBonusDto, dynamic>(
                       "GetTop10RecommendersByBonusesInLastMonth",
                       new { StartDate = startDate, EndDate = endDate },
                       configuration.GetConnectionString("DefaultConnection"),
                       CommandType.StoredProcedure);
                return result.ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EmployeeBonusDto>> GetTop10RecommendersByBonusesInLast3MonthAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await sqlQueryRepository.LoadData<EmployeeBonusDto, dynamic>(
                       "GetTop10RecommendersByBonusesInLast3Month",
                       new { StartDate = startDate, EndDate = endDate },
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
}
