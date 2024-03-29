﻿using CloudEngineering.CodeOps.Abstractions.Commands;
using CloudEngineering.CodeOps.Abstractions.Facade;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices
{
    public sealed class AwsFacade : Facade, IAwsFacade
    {
        private bool _disposedValue;
        private readonly IOptions<AwsFacadeOptions> _options;

        public AwsFacade(IMediator mediator, IOptions<AwsFacadeOptions> options) : base(mediator)
        {
            _options = options;

            if (_options.Value.Impersonate != null)
            {
                Task.WaitAll(Execute(new RegisterProfileCommand(_options.Value.Impersonate, _options.Value.AccessKey, _options.Value.SecretKey)));
            }
        }

        public override async Task<T> Execute<T>(ICommand<T> command, CancellationToken cancellationToken = default)
        {
            return await base.Execute(command, cancellationToken);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_options.Value.Impersonate != null)
                    {
                        Task.WaitAll(Execute(new UnregisterProfileCommand(_options.Value.Impersonate.Name)));
                    }
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);

            System.GC.SuppressFinalize(this);
        }
    }
}
