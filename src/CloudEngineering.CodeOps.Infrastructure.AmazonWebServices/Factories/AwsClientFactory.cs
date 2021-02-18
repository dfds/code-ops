using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security;
using Amazon.Runtime;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Amazon.Extensions.NETCore.Setup;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories
{
    public sealed class AwsClientFactory : IAwsClientFactory
    {
        private readonly IOptions<AWSOptions> _options;

        public AwsClientFactory(IOptions<AWSOptions> options)
        {
            _options = options;
        }

        public async Task<T> Create<T>(IAwsProfile impersonate = default) where T : class
        {
            IAwsCredentials impersonationCredentials = null;

            if (impersonate != null)
            {
                impersonationCredentials = await impersonate.GetCredentials();
            }

            var clientCredentials = impersonationCredentials != null ? new AssumeRoleAWSCredentials(FallbackCredentialsFactory.GetCredentials(), impersonate.RoleArn, impersonationCredentials.RoleSessionName) : FallbackCredentialsFactory.GetCredentials();

            var client = (typeof(T)) switch
            {
                _ => (IAmazonService)typeof(T).GetConstructor(new[] { clientCredentials.GetType(), _options.Value.Region.GetType() })?.Invoke(new object[] { clientCredentials, _options.Value.Region }),
            };

            return client as T;
        }
    }
}
