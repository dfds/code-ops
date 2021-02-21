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
		public int SchemaVersion { get; init; }

		[JsonPropertyName("type")]
		public string Type { get; init; }

		[JsonPropertyName("payload")]
		public JsonElement? Payload { get; init; }

		[JsonConstructor]
		public IntegrationEvent(Guid id, string type, JsonElement payload = default, DateTime creationDate = default, Guid correlationId = default, int schemaVersion = 1)
		{
			Id = id;
			Type = type;
			Payload = payload;
			CreationDate = (creationDate != DateTime.MinValue) ? creationDate : DateTime.UtcNow;
			CorrelationId = correlationId;
			SchemaVersion = schemaVersion;
		}
	}
}
