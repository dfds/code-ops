using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed class AddOrUpdateParameterCommand : AwsCommand<ParameterDto>
    {
        [JsonPropertyName("parameter")]
        public ParameterDto Parameter { get; init; }

        public AddOrUpdateParameterCommand(string parameterName, string parameterValue, string parameterType = "string", bool parameterOverwrite = false, params KeyValuePair<string, string>[] paramTags)
        {
            if (parameterName.EndsWith("/"))
            {
                parameterName = parameterName.TrimEnd('/');
            }

            Parameter = new ParameterDto()
            {
                Name = parameterName,
                Value = parameterValue,
                Overwrite = parameterOverwrite,
                Tags = paramTags,
                ParamType = parameterType
            };
        }
    }
}