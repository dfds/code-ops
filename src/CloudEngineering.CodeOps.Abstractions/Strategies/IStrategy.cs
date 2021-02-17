using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Abstractions.Strategies
{
	public interface IStrategy<T>
	{
		Task Apply(T target, CancellationToken cancellationToken = default);
	}
}
