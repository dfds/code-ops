using CloudEngineering.CodeOps.Abstractions.Facade;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices
{
    public sealed class AwsFacade : Facade, IAwsFacade
    {
        public AwsFacade(IMediator mediator, ILogger<AwsFacade> logger = default) : base(mediator, logger)
        {
        }
    }
}
