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
        private readonly IOptions<AwsFacadeOptions> _options;

        public AwsFacade(IOptions<AwsFacadeOptions> options, IMediator mediator, ILogger<AwsFacade> logger = default) : base(mediator, logger)
        {
            _options = options;

            Task.WaitAll(Execute(new RegisterProfileCommand(_options.Value.Impersonate, _options.Value.AccessKey, _options.Value.SecretKey)));
        }

        public void Dispose()
        {
            Task.WaitAll(Execute(new UnregisterProfileCommand(_options.Value.Impersonate.Name)));
        }
    }
}
