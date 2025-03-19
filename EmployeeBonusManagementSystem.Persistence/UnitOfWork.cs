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
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IDbConnectionFactory _connectionFactory;
		private IDbConnection _connection;
		private IDbTransaction _transaction;
		private bool _disposed;

		public UnitOfWork(IDbConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
			_connection = _connectionFactory.CreateConnection();
			_connection.Open();
		}

		public IDbConnection Connection => _connection;


		public IDbTransaction BeginTransaction()
		{
			if (_transaction == null)
			{
			
				_transaction = _connection.BeginTransaction();
			}
			return _transaction;
		}

		public void Commit()
		{
			if (_transaction == null)
				throw new InvalidOperationException("No active transaction.");

			_transaction.Commit();
			_transaction.Dispose();
			_transaction = null; // Reset transaction
		}

		public void Rollback()
		{
			if (_transaction == null)
				throw new InvalidOperationException("No active transaction.");

			_transaction.Rollback();
			_transaction.Dispose();
			_transaction = null; // Reset transaction
		}

		public async Task<int> CompleteAsync()
		{
			try
			{
				Commit();
				return 1; // Success
			}
			catch (Exception)
			{
				Rollback();
				return 0; // Failure
			}
			finally
			{
				Dispose();
			}
		}

		public void Dispose()
		{
			if (!_disposed)
			{
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
}