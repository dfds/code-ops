using AutoMapper;
using Confluent.Kafka;
using System.Threading;
using System.Threading.Tasks;
using CloudEngineering.CodeOps.Abstractions.Facade;

namespace CloudEngineering.CodeOps.Infrastructure.Kafka.Strategies
{
    public sealed class DefaultConsumptionStrategy : ConsumtionStrategy
    {
        public DefaultConsumptionStrategy(IMapper mapper, IFacade applicationFacade) : base(mapper, applicationFacade)
        {
        }

        public override Task Apply(ConsumeResult<string, string> target, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
