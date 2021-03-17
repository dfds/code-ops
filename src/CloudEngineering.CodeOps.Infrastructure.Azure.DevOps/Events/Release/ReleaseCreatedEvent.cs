namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events.Release
{
    public sealed class ReleaseCreatedEvent : AdoEvent
    {
        public const string EventIdentifier = "ms.vss-release.release-created-event";
    }
}
