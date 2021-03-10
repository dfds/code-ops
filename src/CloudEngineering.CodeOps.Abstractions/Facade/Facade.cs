using CloudEngineering.CodeOps.Abstractions.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Abstractions.Facade
{
    public abstract class Facade : IFacade
    {
        protected readonly IServiceScopeFactory _scopeFactory;

        protected Facade(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
        }

        public virtual async Task<T> Execute<T>(ICommand<T> command, CancellationToken cancellationToken = default)
        {
            using var scope = _scopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            return await mediator.Send(command, cancellationToken);
        }
    }
}
