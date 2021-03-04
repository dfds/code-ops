namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events.Release
{
    public sealed class ReleaseApprovalCompletedEvent : AdoEvent
    {
        public const string EventIdentifier = "ms.vss-release.deployment-approval-completed-event";
    }
}
