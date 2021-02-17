namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events
{
    public sealed class ReleaseCreatedEvent : WebHookEvent
    {
        public const string EventIdentifier = "ms.vss-release.release-created-event";
    }
}
