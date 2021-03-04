namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events.Release
{
    public sealed class ReleaseCompletedEvent : AdoEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-completed-event";
    }
}
