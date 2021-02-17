using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Abstractions.Data
{
	public interface IUnitOfWork : IDisposable
	{
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

		Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);

		Task BeginTransactionAsync();
		
		Task CommitTransactionAsync();
		
		void RollbackTransaction();
	}
}
