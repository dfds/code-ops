using Amazon.Runtime;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public sealed class AwsCredentials : ImmutableCredentials, IAwsCredentials
    {
        public AwsCredentials(string accessKey, string secretKey, string token) : base(accessKey, secretKey, token)
        {
        }

        public static implicit operator AWSCredentials(AwsCredentials c) => c;
        public static explicit operator AwsCredentials(AWSCredentials c) => c.GetCredentials() as AwsCredentials;
    }
}
