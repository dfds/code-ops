namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events
{
    public sealed class ReleaseCompletedEvent : WebHookEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-completed-event";
    }
}
