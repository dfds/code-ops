using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Abstractions.Events
{
	//TODO: Factor this to use JsonConstructor + init and not set accessors once we have migrated to .net 5.0
	public class IntegrationEvent : IIntegrationEvent
	{
		[JsonPropertyName("id")]
		public Guid Id { get; set; } = Guid.NewGuid();

		[JsonPropertyName("creationDate")]
		public DateTime CreationDate { get; set; } = DateTime.UtcNow;

		[JsonPropertyName("correlationId")]
		public Guid CorrelationId { get; set; } = Guid.NewGuid();

		[JsonPropertyName("schemaVersion")]
		public int SchemaVersion { get; set; } = 1;

		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("payload")]
		public JsonElement? Payload { get; set; }
	}
}
