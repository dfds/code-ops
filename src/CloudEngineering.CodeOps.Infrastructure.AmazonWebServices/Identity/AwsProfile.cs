using System;
using System.Threading.Tasks;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security;
using Microsoft.Extensions.Options;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity
{
    public sealed class AwsProfile : IAwsProfile
    {
        private readonly IAwsCredentialResolver _credentialResolver;

        public string SourceProfile { get; init; }

        public string Name { get; init; }

        public string RoleArn { get; init; }

        public AwsProfile(IOptions<AwsFacadeOptions> options)
        {
            SourceProfile = options.Value?.Profile ?? throw new ArgumentNullException(nameof(options));
            var profileLocation = options.Value?.ProfilesLocation ?? throw new ArgumentNullException(nameof(options));

            _credentialResolver = new AwsCredentialResolver(profileLocation);
        }

        public Task<IAwsCredentials> GetCredentials()
        {
            return _credentialResolver.Resolve(this);
        }
    }
}
