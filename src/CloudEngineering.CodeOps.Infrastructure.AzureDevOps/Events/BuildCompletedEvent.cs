namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events
{
    public sealed class BuildCompletedEvent : WebHookEvent
    {
        public const string EventIdentifier = "build.complete";
    }
}
