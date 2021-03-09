using Amazon.Runtime.CredentialManagement;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using Microsoft.Extensions.Options;
using System;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public sealed class AwsCredentialResolver : IAwsCredentialResolver
    {
        private readonly CredentialProfileStoreChain _credentialProfileStoreChain;

        public AwsCredentialResolver(IOptions<AwsFacadeOptions> options)
        {
            Console.WriteLine($"ctor.SecretKey: {options.Value.SecretKey}");
            Console.WriteLine($"ctor.ProfilesLocation: {options.Value.ProfilesLocation}");
            _credentialProfileStoreChain = new CredentialProfileStoreChain(options.Value.ProfilesLocation);
        }

        public AwsCredentialResolver(string profilesLocation)
        {
            _credentialProfileStoreChain = new CredentialProfileStoreChain(profilesLocation);
        }

        public AwsCredentials Resolve(IAwsProfile profile = default)
        {
            Console.WriteLine($"Resolve.profileName: {profile?.Name}");

            if (string.IsNullOrEmpty(profile?.Name))
            {
                return null;
            }

            if (!_credentialProfileStoreChain.TryGetAWSCredentials(profile?.Name, out var credentialsHandle))
            {
                throw new AwsFacadeException($"Failed to retrieve credentials for profile: {profile?.Name}");
            }

            Console.WriteLine($"Yay!! We made it!!");

            return (AwsCredentials)credentialsHandle.GetCredentials(); 
        }
    }
}
