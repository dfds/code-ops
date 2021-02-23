using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed class GetParameterCommand : AwsCommand<ParameterDto>
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        public GetParameterCommand(string parameterName)
        {
            if (parameterName.EndsWith("/"))
            {
                parameterName = parameterName.TrimEnd('/');
            }

            Name = parameterName;
        }
    }
}