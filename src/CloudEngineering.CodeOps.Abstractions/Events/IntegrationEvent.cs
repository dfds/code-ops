using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Abstractions.Events
{
	public class IntegrationEvent : IIntegrationEvent
	{
		[JsonPropertyName("id")]
		public Guid Id { get; init; }

		[JsonPropertyName("creationDate")]
		public DateTime CreationDate { get; init; }

		[JsonPropertyName("correlationId")]
		public Guid CorrelationId { get; init; }

		[JsonPropertyName("schemaVersion")]
		public string SchemaVersion { get; init; }

		[JsonPropertyName("type")]
		public string Type { get; init; }

		[JsonPropertyName("payload")]
		public JsonElement? Payload { get; init; }

		[JsonConstructor]
		public IntegrationEvent(string type, JsonElement? payload, Guid correlationId = default, string schemaVersion = "1") : this(type, payload, correlationId, schemaVersion, Guid.NewGuid(), DateTime.UtcNow)
		{
		}

		public IntegrationEvent(string type, JsonElement? payload = default, Guid correlationId = default, string schemaVersion = "1", Guid id = default, DateTime creationDate = default)
		{
			Type = type;
			Payload = payload;
			CorrelationId = correlationId;
			SchemaVersion = schemaVersion;
			Id = id;
			CreationDate = (creationDate != DateTime.MinValue) ? creationDate : DateTime.UtcNow;
		}
	}
}
