namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.Events
{
    public sealed class ReleaseCompletedEvent : WebHookEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-completed-event";
    }
}
