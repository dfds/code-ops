using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed class DeleteParameterCommand : AwsCommand<Task>
    {
        [JsonPropertyName("paramName")]
        public string ParamName { get; init; }

        public DeleteParameterCommand(string parameterName)
        {
            if (parameterName.EndsWith("/"))
            {
                parameterName = parameterName.TrimEnd('/');
            }

            ParamName = parameterName;
        }
    }
}