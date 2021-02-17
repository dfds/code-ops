namespace CloudEngineering.CodeOps.Infrastructure.Vsts.Events
{
    public sealed class ReleaseCreatedEvent : WebHookEvent
    {
        public const string EventIdentifier = "ms.vss-release.release-created-event";
    }
}
