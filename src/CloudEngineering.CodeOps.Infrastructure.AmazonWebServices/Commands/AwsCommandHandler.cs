using CloudEngineering.CodeOps.Abstractions.Commands;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands
{
    public abstract class AwsCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        protected readonly IAwsProfile _fallbackProfile;
        protected readonly IAwsClientFactory _awsClientFactory;

        protected AwsCommandHandler(IAwsClientFactory awsClientFactory = default, IAwsProfile fallbackProfile = default)
        {
            _awsClientFactory = awsClientFactory ?? throw new ArgumentNullException(nameof(awsClientFactory));
            _fallbackProfile = fallbackProfile;
        }

        public abstract Task<TResult> Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}
