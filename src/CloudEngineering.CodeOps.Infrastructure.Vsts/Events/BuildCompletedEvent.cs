namespace CloudEngineering.CodeOps.Infrastructure.Vsts.Events
{
    public sealed class BuildCompletedEvent : WebHookEvent
    {
        public const string EventIdentifier = "build.complete";
    }
}
