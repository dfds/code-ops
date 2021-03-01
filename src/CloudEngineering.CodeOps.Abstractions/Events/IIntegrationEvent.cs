using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Abstractions.Events
{
	public interface IIntegrationEvent : IEvent
	{
		[JsonPropertyName("id")]
		string Id { get; }

		[JsonPropertyName("correlationId")]
		string CorrelationId { get; }

		[JsonPropertyName("creationDate")]
		DateTime CreationDate { get; }

		[JsonPropertyName("schemaVersion")]
		string SchemaVersion { get; }

		[JsonPropertyName("type")]
		string Type { get; }

		[JsonPropertyName("payload")]
		JsonElement? Payload { get; }
	}
}
