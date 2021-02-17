namespace CloudEngineering.CodeOps.Infrastructure.AdoClient.Events
{
    public sealed class BuildCompletedEvent : WebHookEvent
    {
        public const string EventIdentifier = "build.complete";
    }
}
