using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using CloudEngineering.CodeOps.Infrastructure.Kafka.Serialization;
using CloudEngineering.CodeOps.Infrastructure.Kafka.Strategies;
using CloudEngineering.CodeOps.Abstractions.Events;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Kafka.UnitTest
{
    public class DefaultValueSerializerTests
    {
        [Fact]
        public void CanSerialize()
        {
            // Arrange
            SerializationContext testContext = new SerializationContext(MessageComponentType.Key,null,null);
            DefaultValueSerializer<string> testSerializer = new DefaultValueSerializer<string>();
            string testPayload = new string("Test Payload");

            // Act
            var returnValue = testSerializer.Serialize(testPayload, testContext);

            // Assert
            Assert.NotNull(returnValue);
            Assert.Equal(returnValue, testSerializer.Serialize(testPayload,testContext));
        }
    }
}

