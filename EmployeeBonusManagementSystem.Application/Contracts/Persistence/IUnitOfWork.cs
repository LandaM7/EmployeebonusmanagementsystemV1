namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence;
public interface IUnitOfWork
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}