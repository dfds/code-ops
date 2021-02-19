using MediatR;

namespace CloudEngineering.CodeOps.Abstractions.Commands
{
	public interface ICommand<out TResponse> : IRequest<TResponse>
	{

	}
}
