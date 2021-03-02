namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity
{
    public interface IAwsProfile
    {
        string SourceProfile { get; }

        string Name { get; }

        string RoleArn { get; }
    }

}
