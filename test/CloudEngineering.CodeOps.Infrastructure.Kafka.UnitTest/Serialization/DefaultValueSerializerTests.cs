using CloudEngineering.CodeOps.Infrastructure.Kafka.Serialization;
using Confluent.Kafka;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Kafka.UnitTest
{
    public class DefaultValueSerializerTests
    {
        [Fact]
        public void CanSerialize()
        {
            // Arrange
            SerializationContext testContext = new SerializationContext(MessageComponentType.Key, null, null);
            DefaultValueSerializer<string> testSerializer = new DefaultValueSerializer<string>();
            string testPayload = new string("Test Payload");

            // Act
            var returnValue = testSerializer.Serialize(testPayload, testContext);

            // Assert
            Assert.NotNull(returnValue);
            Assert.Equal(returnValue, testSerializer.Serialize(testPayload, testContext));
        }
    }
}

