using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Events;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Mapping.Converters
{
    public class JsonElementToWebHookEventConverter : ITypeConverter<JsonElement, WebHookEvent>
    {
        public WebHookEvent Convert(JsonElement source, WebHookEvent destination, ResolutionContext context)
        {
            return JsonSerializer.Deserialize<WebHookEvent>(source.GetRawText());
        }
    }
}
