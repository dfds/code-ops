using CloudEngineering.CodeOps.Abstractions.Entities;

namespace CloudEngineering.CodeOps.Abstractions.Aggregates
{
	public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot where TKey : struct
	{

	}
}
