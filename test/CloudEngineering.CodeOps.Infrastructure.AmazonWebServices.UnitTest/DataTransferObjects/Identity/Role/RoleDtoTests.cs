using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Role;
using System.Text.Json;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.UnitTest.Identity.Policy.Role
{
    public class RoleDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            RoleDto sut;

            //Act
            sut = new RoleDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new RoleDto()
            {
                RoleId = "roleId",
                RoleName = "roleName",
                Arn = "arn",
                AssumeRolePolicyDocument = "policyDocument",
                Description = "description",
                MaxSessionDuration = 10,
                Path = "path"
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
            RoleDto sut;

            //Act
            sut = JsonSerializer.Deserialize<RoleDto>("{\"arn\":\"arn\",\"assumeRolePolicyDocument\":\"policyDocument\",\"description\":\"description\",\"maxSessionDuration\":10,\"path\":\"path\",\"roleId\":\"roleId\",\"roleName\":\"roleName\"}");

            //Assert
            Assert.NotNull(sut);
        }
    }
}