namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events.Release
{
    public sealed class ReleaseCompletedEvent : AdoEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-completed-event";
    }
}
