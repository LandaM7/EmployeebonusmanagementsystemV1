using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence.Common;
using EmployeeBonusManagementSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeBonusManagementSystem.Infrastructure.Repositories
{
    public class EmployeeRepository(
        ISqlQueryRepository sqlQueryRepository,
        IConfiguration configuration)
        : IEmployeeRepository
    {

        public async Task<EmployeeEntity?> GetByPersonalNumberAsync(string personalNumber)
        {
            try
            {
                var query = @"
                    SELECT 
                        Id AS EmployeeId 
                    FROM
                        [HRManagementEmployee].[dbo].[Employees](NOLOCK)
                    WHERE
                        PersonalNumber = @PersonalNumber;
                ";

                return await sqlQueryRepository.LoadDataFirstOrDefault<EmployeeEntity, dynamic>(
                    query,
                    new { PersonalNumber = personalNumber },
                    configuration.GetConnectionString("DefaultConnection"),
                    CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
