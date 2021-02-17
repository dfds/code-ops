namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events
{
    public sealed class ReleaseAbandonedEvent : WebHookEvent
    {
        public const string EventIdentifier = "ms.vss-release.release-abandoned-event";
    }
}
