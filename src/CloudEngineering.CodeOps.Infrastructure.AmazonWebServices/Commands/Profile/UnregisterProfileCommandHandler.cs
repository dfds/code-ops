using Amazon.Runtime.CredentialManagement;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile
{
    public sealed class UnregisterProfileCommandHandler : AwsCommandHandler<RegisterProfileCommand, Task>
    {
        private readonly CredentialProfileStoreChain _credentialProfileStoreChain;

        public UnregisterProfileCommandHandler(string profileLocation)
        {
            _credentialProfileStoreChain = new CredentialProfileStoreChain(profileLocation);
        }

        public override Task<Task> Handle(RegisterProfileCommand command, CancellationToken cancellationToken = default)
        {
            var profileOptions = new CredentialProfileOptions
            {
                SourceProfile = command.Impersonate.SourceProfile,
                RoleArn = command.Impersonate.RoleArn,
                AccessKey = command.AccessKey,
                SecretKey = command.SecretKey
            };

            var credentialProfile = new CredentialProfile(command.Impersonate.Name, profileOptions);

            _credentialProfileStoreChain.RegisterProfile(credentialProfile);

            return Task.FromResult(Task.CompletedTask);
        }
    }
}
