using CloudEngineering.CodeOps.Abstractions.Facade;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices
{
    public sealed class AwsFacade : Facade, IAwsFacade
    {
        private bool _disposed = false;
        private readonly IOptions<AwsFacadeOptions> _options;

        public AwsFacade(IOptions<AwsFacadeOptions> options, IMediator mediator, ILogger<AwsFacade> logger = default) : base(mediator, logger)
        {
            _options = options;

            Task.WaitAll(Execute(new RegisterProfileCommand(_options.Value.Impersonate, _options.Value.AccessKey, _options.Value.SecretKey)));
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                var command = new UnregisterProfileCommand(_options.Value.Impersonate.Name);

                Task.WaitAll(Execute(command));
            }

            _disposed = true;
        }
    }
}
