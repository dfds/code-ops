namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events
{
    public sealed class ReleaseApprovalPendingEvent : WebHookEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-approval-pending-event";
    }
}
