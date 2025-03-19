using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence.Common;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeBonusManagementSystem.Infrastructure.Repositories
{
    public class EmployeeRepository(
        ISqlQueryRepository sqlQueryRepository,
        IConfiguration configuration)
        : IEmployeeRepository
    {

        public async Task<(bool, int)> GetEmployeeExistsByPersonalNumberAsync(string personalNumber)
        {
            try
            {
                var query = @"
                    SELECT 
                        Id 
                    FROM
                        [HRManagementEmployee].[dbo].[Employees](NOLOCK)
                    WHERE
                        PersonalNumber = @PersonalNumber;
                ";

                var result = await sqlQueryRepository.LoadDataFirstOrDefault<int, dynamic>(
                    query,
                    new { PersonalNumber = personalNumber },
                    configuration.GetConnectionString("DefaultConnection"),
                    CommandType.Text);

                return (result > 0, result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
