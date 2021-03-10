using Amazon;
using Amazon.Runtime;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security;
using Microsoft.Extensions.Options;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories
{
    public sealed class AwsClientFactory : IAwsClientFactory
    {
        private readonly IOptions<AwsFacadeOptions> _options;
        private readonly IAwsCredentialResolver _awsCredentialResolver;

        public AwsClientFactory(IOptions<AwsFacadeOptions> options, IAwsCredentialResolver awsCredentialResolver = default)
        {
            _options = options;
            _awsCredentialResolver = awsCredentialResolver ?? new AwsCredentialResolver(_options);
        }

        public T Create<T>(IAwsProfile assumeProfile = default) where T : IAmazonService
        {
            AWSCredentials impersonateCredentials = _awsCredentialResolver.Resolve(_options.Value.Impersonate) ?? FallbackCredentialsFactory.GetCredentials();
            AWSCredentials sdkClientCredentials = impersonateCredentials;

            if (assumeProfile != null)
            {
                var assumeProfileCredentials = _awsCredentialResolver.Resolve(assumeProfile);

                sdkClientCredentials = new AssumeRoleAWSCredentials(impersonateCredentials, assumeProfile.RoleArn, assumeProfileCredentials.Token);
            }

            var clientOfTConstructor = typeof(T).GetConstructor(new[] { typeof(AWSCredentials), typeof(RegionEndpoint) });
            var clientOfT = (T)clientOfTConstructor.Invoke(new object[] { sdkClientCredentials, RegionEndpoint.GetBySystemName(_options.Value.Region) });

            return clientOfT;
        }
    }
}
