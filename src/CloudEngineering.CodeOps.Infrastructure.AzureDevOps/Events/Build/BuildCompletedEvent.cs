namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events.Build
{
    public sealed class BuildCompletedEvent : AdoEvent
    {
        public const string EventIdentifier = "build.complete";
    }
}
