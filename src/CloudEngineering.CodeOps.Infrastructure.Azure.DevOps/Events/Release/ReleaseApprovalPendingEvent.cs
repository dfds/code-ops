namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events.Release
{
    public sealed class ReleaseApprovalPendingEvent : AdoEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-approval-pending-event";
    }
}
