using Amazon.Runtime;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public sealed class AwsCredentials : IAwsCredentials
    {
        public string AccessKey { get; init; }

        public string SecretKey { get; init; }

        public string Token { get; init; }

        public AwsCredentials(string accessKey, string secretKey, string token)
        {
            AccessKey = accessKey;
            SecretKey = secretKey;
            Token = token;
        }

        public static implicit operator ImmutableCredentials(AwsCredentials awsCredentials) => new ImmutableCredentials(awsCredentials.AccessKey, awsCredentials.SecretKey, awsCredentials.Token);
        public static explicit operator AwsCredentials(ImmutableCredentials awsCredentials) => new AwsCredentials(awsCredentials.AccessKey, awsCredentials.SecretKey, awsCredentials.Token);

        public static implicit operator AWSCredentials(AwsCredentials c) => !string.IsNullOrEmpty(c.Token) ? new SessionAWSCredentials(c.AccessKey, c.SecretKey, c.Token) : new BasicAWSCredentials(c.AccessKey, c.SecretKey);
        public static explicit operator AwsCredentials(AWSCredentials c) => (AwsCredentials)c.GetCredentials();
    }
}
