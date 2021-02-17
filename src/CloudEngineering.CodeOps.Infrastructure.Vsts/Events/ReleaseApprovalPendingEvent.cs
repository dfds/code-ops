namespace CloudEngineering.CodeOps.Infrastructure.Vsts.Events
{
    public sealed class ReleaseApprovalPendingEvent : WebHookEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-approval-pending-event";
    }
}
