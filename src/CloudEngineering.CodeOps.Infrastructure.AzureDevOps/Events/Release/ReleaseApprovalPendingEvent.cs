namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events.Release
{
    public sealed class ReleaseApprovalPendingEvent : AdoEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-approval-pending-event";
    }
}
