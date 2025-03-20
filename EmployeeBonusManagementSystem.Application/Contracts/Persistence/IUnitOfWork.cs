using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBonusManagementSystem.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

	    IDbTransaction BeginTransaction(); 
	    Task BeginTransactionAsync(); 
	    void Commit();
	    Task CommitAsync();
	    void Rollback();
	    Task RollbackAsync();
	    IDbConnection Connection { get; } 
	    Task<int> CompleteAsync(); 
	}
}
