using System.Threading;
using System.Threading.Tasks;
using CloudEngineering.CodeOps.Abstractions.Commands;

namespace CloudEngineering.CodeOps.Abstractions.Facade
{
	public interface IFacade
	{
		Task<T> Execute<T>(ICommand<T> command, CancellationToken cancellationToken = default);
	}
}
