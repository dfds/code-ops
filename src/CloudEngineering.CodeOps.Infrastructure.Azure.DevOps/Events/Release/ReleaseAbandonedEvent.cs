namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events.Release
{
    public sealed class ReleaseAbandonedEvent : AdoEvent
    {
        public const string EventIdentifier = "ms.vss-release.release-abandoned-event";
    }
}
