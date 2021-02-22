namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices
{
    public sealed class AwsFacadeOptions
    {
        public const string AwsFacade = "AwsFacade";

        public string Profile { get; set; }

        public string ProfilesLocation { get; set; }

        public string Region { get; set; }
    }
}
