namespace CloudEngineering.CodeOps.Infrastructure.Vsts.Events
{
    public sealed class ReleaseApprovalCompletedEvent : WebHookEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-approval-completed-event";
    }
}
