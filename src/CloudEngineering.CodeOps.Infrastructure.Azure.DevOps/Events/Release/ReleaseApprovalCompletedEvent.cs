namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events.Release
{
    public sealed class ReleaseApprovalCompletedEvent : AdoEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-approval-completed-event";
    }
}
