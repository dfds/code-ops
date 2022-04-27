using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Abstractions.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Abstractions.Repositories
{
    public abstract class Repository<TContext, TAggregate> : IRepository<TAggregate>
        where TContext : class, IUnitOfWork
        where TAggregate : IAggregateRoot
    {
        protected readonly TContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        protected Repository(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public abstract TAggregate Add(TAggregate aggregate);

        public abstract TAggregate Update(TAggregate aggregate);

        public abstract void Delete(TAggregate aggregate);

        public abstract Task<IEnumerable<TAggregate>> GetAsync(Expression<Func<TAggregate, bool>> filter, CancellationToken ct = default);
    }
}
