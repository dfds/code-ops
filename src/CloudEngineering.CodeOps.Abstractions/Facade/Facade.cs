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
        public abstract Task<T> Execute<T>(ICommand<T> command, CancellationToken cancellationToken = default);
    }
}
