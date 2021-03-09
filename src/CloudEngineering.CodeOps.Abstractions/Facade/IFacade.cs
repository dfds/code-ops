using CloudEngineering.CodeOps.Abstractions.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Abstractions.Facade
{
    public interface IFacade
    {
        Task<T> Execute<T>(ICommand<T> command, CancellationToken cancellationToken = default);
    }
}
