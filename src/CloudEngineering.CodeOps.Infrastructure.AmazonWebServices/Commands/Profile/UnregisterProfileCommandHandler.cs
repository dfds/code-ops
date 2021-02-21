using Amazon.Runtime.CredentialManagement;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile
{
    public sealed class UnregisterProfileCommandHandler : AwsCommandHandler<UnregisterProfileCommand, Task>
    {
        private readonly CredentialProfileStoreChain _credentialProfileStoreChain;

        public UnregisterProfileCommandHandler(string profileLocation)
        {
            _credentialProfileStoreChain = new CredentialProfileStoreChain(profileLocation);
        }

        public override Task<Task> Handle(UnregisterProfileCommand command, CancellationToken cancellationToken = default)
        {
            if (_credentialProfileStoreChain.TryGetProfile(command.ProfileName, out _)) return Task.FromResult(Task.CompletedTask);

            _credentialProfileStoreChain.UnregisterProfile(command.ProfileName);

            return Task.FromResult(Task.CompletedTask);
        }
    }
}
