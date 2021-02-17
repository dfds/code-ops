namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.Events
{
    public sealed class ReleaseApprovalPendingEvent : WebHookEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-approval-pending-event";
    }
}
