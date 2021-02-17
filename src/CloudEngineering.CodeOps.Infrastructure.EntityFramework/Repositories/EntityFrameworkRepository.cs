using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CloudEngineering.CodeOps.Infrastructure.EntityFramework.Repositories
{
    public abstract class EntityFrameworkRepository<TAggregate, TContext> : Repository<TContext, TAggregate>
        where TAggregate : class, IAggregateRoot
        where TContext : EntityContext
    {
        protected EntityFrameworkRepository(TContext context) : base(context)
        {

        }

        public override TAggregate Add(TAggregate aggregate)
        {
            return _context.Add(aggregate).Entity;
        }

        public override TAggregate Update(TAggregate aggregate)
        {
            var changeTracker = _context.Entry(aggregate);

            changeTracker.State = EntityState.Modified;

            return changeTracker.Entity;
        }

        public override void Delete(TAggregate aggregate)
        {
            _context.Entry(aggregate).State = EntityState.Deleted;
        }
    }
}
