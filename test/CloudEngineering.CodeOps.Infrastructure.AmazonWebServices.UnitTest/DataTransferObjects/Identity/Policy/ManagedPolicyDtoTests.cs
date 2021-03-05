using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy;
using System.Text.Json;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.UnitTest.Identity.Policy
{
    public class ManagedPolicyDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            ManagedPolicyDto sut;

            //Act
            sut = new ManagedPolicyDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new ManagedPolicyDto()
            {
                Description = "description",
                Arn = "arn",
                Path = "path",
                PolicyId = "policyId",
                PolicyName = "policyName"                
            };

            //Act
            var payload = JsonSerializer.Serialize(sut, new JsonSerializerOptions { IgnoreNullValues = true });

            //Assert
            Assert.NotNull(JsonDocument.Parse(payload));
        }

        [Fact]
        public void CanBeDeserialized()
        {
            //Arrange
            ManagedPolicyDto sut;

            //Act
            sut = JsonSerializer.Deserialize<ManagedPolicyDto>("{\"arn\":\"arn\",\"policyId\":\"policyId\",\"policyName\":\"policyName\",\"description\":\"description\",\"path\":\"path\"}");

            //Assert
            Assert.NotNull(sut);
        }
    }
}