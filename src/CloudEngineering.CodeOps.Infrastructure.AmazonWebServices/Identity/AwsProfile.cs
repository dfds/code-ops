namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity
{
    public sealed class AwsProfile : IAwsProfile
    {
        public string SourceProfile { get; set; }

        public string Name { get; set; }

        public string RoleArn { get; set; }
    }
}
