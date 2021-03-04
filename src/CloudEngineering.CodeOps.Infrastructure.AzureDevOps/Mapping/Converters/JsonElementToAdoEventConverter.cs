using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Mapping.Converters
{
    public class JsonElementToAdoEventConverter : ITypeConverter<JsonElement, AdoEvent>
    {
        public AdoEvent Convert(JsonElement source, AdoEvent destination, ResolutionContext context)
        {
            return JsonSerializer.Deserialize<AdoEvent>(source.GetRawText());
        }
    }
}
