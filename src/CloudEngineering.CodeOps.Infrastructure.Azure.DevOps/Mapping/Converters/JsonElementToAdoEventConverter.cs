using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Events;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Mapping.Converters
{
    public class JsonElementToAdoEventConverter : ITypeConverter<JsonElement, AdoEvent>
    {
        public AdoEvent Convert(JsonElement source, AdoEvent destination, ResolutionContext context)
        {
            return JsonSerializer.Deserialize<AdoEvent>(source.GetRawText());
        }
    }
}
