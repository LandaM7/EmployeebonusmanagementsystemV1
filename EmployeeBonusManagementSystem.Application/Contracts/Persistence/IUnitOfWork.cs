using EmployeeBonusManagementSystem.Application.Contracts.Persistence.Common;

namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence;
public interface IUnitOfWork
{
    ISqlCommandRepository SqlCommandRepository { get; }
    ISqlQueryRepository SqlQueryRepository { get; }
    IBonusRepository BonusRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    IReportRepository ReportRepository { get; }
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task CloseAsync();
    Task OpenAsync();
}
