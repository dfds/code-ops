using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed class AddOrUpdateParameterCommand : AwsCommand<ParameterDto>
    {
        [JsonPropertyName("parameter")]
        public ParameterDto Parameter { get; init; }

        public AddOrUpdateParameterCommand(string name, string value, string type = "string", bool overwrite = false, params KeyValuePair<string, string>[] tags)
        {
            if (name.EndsWith("/"))
            {
                name = name.TrimEnd('/');
            }

            Parameter = new ParameterDto()
            {
                Name = name,
                Value = value,
                Overwrite = overwrite,
                Tags = tags,
                ParamType = type
            };
        }
    }
}