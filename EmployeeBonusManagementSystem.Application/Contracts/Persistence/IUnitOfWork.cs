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
		void Commit();
		void Rollback();
		IDbConnection Connection { get; }
		Task<int> CompleteAsync();
	}
}