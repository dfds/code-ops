namespace CloudEngineering.CodeOps.Abstractions.Telemetry
{
    public interface ITelemetryProvider
    {
        T GetClient<T>() where T : class;
    }
}
