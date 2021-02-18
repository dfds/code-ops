namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public class AwsCredentials : IAwsCredentials
    {
        public string AccessKey { get; init; }

        public string SecretKey { get; init; }

        public string RoleSessionName { get; init; }

        public AwsCredentials(string accessKey, string secretKey, string roleSessionName)
        {
            AccessKey = accessKey;
            SecretKey = secretKey;
            RoleSessionName = roleSessionName;
        }
    }
}
