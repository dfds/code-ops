using MediatR;

namespace CloudEngineering.CodeOps.Abstractions.Commands
{
	//TODO: Consider if we should constrain this to Task or IAsyncResult + IDisposable to force async behavior on all commands.
	public interface ICommand<out TResponse> : IRequest<TResponse>
	{

	}
}
