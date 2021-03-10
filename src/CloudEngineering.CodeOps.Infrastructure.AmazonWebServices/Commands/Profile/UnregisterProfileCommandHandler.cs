using Amazon.Runtime.CredentialManagement;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile
{
    public sealed class UnregisterProfileCommandHandler : AwsCommandHandler<UnregisterProfileCommand, Task>
    {
        private readonly CredentialProfileStoreChain _credentialProfileStoreChain;

        public UnregisterProfileCommandHandler(IOptions<AwsFacadeOptions> options)
        {
            _credentialProfileStoreChain = new CredentialProfileStoreChain(options.Value.ProfilesLocation);
        }

        public override Task<Task> Handle(UnregisterProfileCommand command, CancellationToken cancellationToken = default)
        {
            _credentialProfileStoreChain.UnregisterProfile(command.ProfileName);

            return Task.FromResult(Task.CompletedTask);
        }
    }
}
