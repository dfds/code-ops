using Amazon.Runtime.CredentialManagement;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using Microsoft.Extensions.Options;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public sealed class AwsCredentialResolver : IAwsCredentialResolver
    {
        private readonly CredentialProfileStoreChain _credentialProfileStoreChain;

        public AwsCredentialResolver(IOptions<AwsFacadeOptions> options)
        {
            _credentialProfileStoreChain = new CredentialProfileStoreChain(options.Value.ProfilesLocation);
        }

        public IAwsCredentials Resolve(IAwsProfile profile = default)
        {
            if (!_credentialProfileStoreChain.TryGetAWSCredentials(profile?.Name, out var credentialsHandle))
            {
                throw new AwsFacadeException($"Failed to retrieve credentials for profile: {profile?.Name}");
            }

            return credentialsHandle.GetCredentials() as IAwsCredentials; 
        }
    }
}
