using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using System;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public sealed class AwsCredentialResolver : IAwsCredentialResolver
    {
        private readonly CredentialProfileStoreChain _credentialProfileStoreChain;

        public AwsCredentialResolver(string profileLocation)
        {
            _credentialProfileStoreChain = new CredentialProfileStoreChain(profileLocation);
        }

        public async Task<IAwsCredentials> Resolve(IAwsProfile profile = default, string roleSessionName = default)
        {
            if (!_credentialProfileStoreChain.TryGetAWSCredentials(profile?.Name, out var credentialsHandle))
            {
                throw new ArgumentException($"Failed to retrieve credentials for profile: {profile?.Name}");
            }

            var credentials = await credentialsHandle.GetCredentialsAsync();

            if (credentialsHandle is AssumeRoleAWSCredentials awsCredentials)
            {
                roleSessionName = awsCredentials.RoleSessionName;
            }
            
            return new AwsCredentials(credentials.AccessKey, credentials.SecretKey, roleSessionName);
        }
    }
}
