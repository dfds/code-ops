using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.EntityFramework.Transactions
{
    public sealed class ResilientTransaction
    {
        private readonly DbContext _context;

        private ResilientTransaction(DbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public static ResilientTransaction New(DbContext context) => new ResilientTransaction(context);

        public async Task ExecuteAsync(Func<Task> action)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = _context.Database.BeginTransaction();

                await action();

                transaction.Commit();
            });
        }
    }
}
