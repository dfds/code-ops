using System.Collections.Generic;

namespace CloudEngineering.CodeOps.Abstractions.Grid.Provisioning
{
    public interface IDesiredState
    {
        string Name { get; }

        string ApiVersion { get; }

        IEnumerable<KeyValuePair<string, string>> Labels { get; }

        IEnumerable<KeyValuePair<string, string>> Properties { get; }
    }
}
