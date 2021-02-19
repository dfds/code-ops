using Amazon.SimpleSystemsManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed class AddOrUpdateParameterCommand : AwsCommand<Task>
    {
        public string ParamName { get; init; }

        public string ParamValue { get; init; }

        public string ParamType { get; init; }

        public KeyValuePair<string, string>[] ParamTags { get; init; }

        public bool ParamOverwrite { get; init; }

        public AddOrUpdateParameterCommand(string parameterName, string parameterValue, string parameterType = "string", bool parameterOverwrite = false, params KeyValuePair<string, string>[] paramTags)
        {
            if (parameterName.EndsWith("/"))
            {
                parameterName = parameterName.TrimEnd('/');
            }

            ParamName = parameterName;
            ParamValue = parameterValue;
            ParamType = ParameterType.FindValue(parameterType);
            ParamOverwrite = parameterOverwrite;
            ParamTags = paramTags;
        }
    }
}