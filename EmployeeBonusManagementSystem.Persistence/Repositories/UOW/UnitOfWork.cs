using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeBonusManagementSystem.Persistence.Repositories.UOW;
public class UnitOfWork(
    ApplicationDbContext context,
    IServiceProvider serviceProvider)
    : IUnitOfWork
{
    public ISqlCommandRepository SqlCommandRepository => serviceProvider.GetService<ISqlCommandRepository>();
    public ISqlQueryRepository SqlQueryRepository => serviceProvider.GetService<ISqlQueryRepository>();
    public IBonusRepository BonusRepository => serviceProvider.GetService<IBonusRepository>();
    public IEmployeeRepository EmployeeRepository => serviceProvider.GetService<IEmployeeRepository>();
    public IReportRepository ReportRepository => serviceProvider.GetService<IReportRepository>();

    public async Task BeginTransactionAsync()
    {
        await context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await context.Database.CommitTransactionAsync();
    }
    public async Task CloseAsync()
    {
        if (await context.Database.CanConnectAsync())
            await context.Database.CloseConnectionAsync();
    }

    public async Task OpenAsync()
    {
        if (await context.Database.CanConnectAsync())
            await context.Database.OpenConnectionAsync();
    }
    public async Task RollbackAsync()
    {
        if (await context.Database.CanConnectAsync())
            await context.Database.RollbackTransactionAsync();
    }
    public async Task GetTransaction()
    {
        if (await context.Database.CanConnectAsync())
            await context.Database.RollbackTransactionAsync();
    }
}
