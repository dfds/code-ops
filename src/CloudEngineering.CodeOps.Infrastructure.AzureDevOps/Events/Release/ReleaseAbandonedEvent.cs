namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events.Release
{
    public sealed class ReleaseAbandonedEvent : AdoEvent
    {
        public const string EventIdentifier = "ms.vss-release.release-abandoned-event";
    }
}
