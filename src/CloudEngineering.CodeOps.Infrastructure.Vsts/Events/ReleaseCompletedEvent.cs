namespace CloudEngineering.CodeOps.Infrastructure.Vsts.Events
{
    public sealed class ReleaseCompletedEvent : WebHookEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-completed-event";
    }
}
