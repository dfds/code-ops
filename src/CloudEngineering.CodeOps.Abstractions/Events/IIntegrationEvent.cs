using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Abstractions.Events
{
	public interface IIntegrationEvent : IEvent
	{
		[JsonPropertyName("id")]
		Guid Id { get; }

		[JsonPropertyName("correlationId")]
		Guid CorrelationId { get; }

		[JsonPropertyName("creationDate")]
		DateTime CreationDate { get; }

		[JsonPropertyName("schemaVersion")]
		int SchemaVersion { get; }

		[JsonPropertyName("type")]
		string Type { get; }

		[JsonPropertyName("payload")]
		JsonElement? Payload { get; }
	}
}
