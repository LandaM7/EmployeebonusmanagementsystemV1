using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using Microsoft.Extensions.DependencyInjection;


namespace EmployeeBonusManagementSystem.Infrastructure;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {

        services.AddScoped<IReportRepository, ReportRepository>(); // დავამატე

        return services;
    }
}



