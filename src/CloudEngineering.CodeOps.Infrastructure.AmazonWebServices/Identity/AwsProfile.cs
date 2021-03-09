namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity
{
    public sealed class AwsProfile : IAwsProfile
    {
        public string SourceProfile { get; init; }

        public string Name { get; init; }

        public string RoleArn { get; init; }
    }
}
