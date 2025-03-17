using Microsoft.Extensions.DependencyInjection;

namespace EmployeeBonusManagementSystem.Application;

public static class ApplicationDI
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        return services;
    }
}
