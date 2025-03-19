using System;
using System.Data;
using System.Threading.Tasks;
using EmployeeBonusManagementSystem.Application.Contracts.Persistence;
using EmployeeBonusManagementSystem.Infrastructure.Repositories;
using EmployeeBonusManagementSystem.Persistence.Repositories.Implementations;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmployeeBonusManagementSystem.Persistence
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly IDbConnection _connection;
		private readonly IDbTransaction _transaction;
		private bool _disposed;

		private IEmployeeRepository _employeeRepository;

		public IEmployeeRepository EmployeeRepository =>
			_employeeRepository ??= new EmployeeRepository(_connection, _transaction);

		public UnitOfWork(IConfiguration configuration)
		{
			_connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
			_connection.Open();
			_transaction = _connection.BeginTransaction();
		}

		public async Task<int> CompleteAsync()
		{
			try
			{
				await Task.Run(() => _transaction.Commit());
				return 1; // Success
			}
			catch
			{
				_transaction.Rollback();
				return 0; // Failure
			}
			finally
			{
				Dispose();
			}
		}

		public void Dispose()
		{
			if (_disposed)
				return;

			_transaction?.Dispose();
			if (_connection?.State == ConnectionState.Open)
			{
				_connection.Close();
			}
			_connection?.Dispose();
			_disposed = true;
		}
	}
}