using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Commands.Identity.Role
{
    public class CreateAndDeleteRoleCommandTests : IClassFixture<AwsFacadeFixture>
    {
        private readonly AwsFacadeFixture _fixture;

        public CreateAndDeleteRoleCommandTests(AwsFacadeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CanCreateAndDeleteRole()
        {
            //Arrange
            using var facade = _fixture.Facade;

            var roleName = Guid.NewGuid().ToString();
            var command = new CreateRoleCommand(roleName, "{\"Version\": \"2012-10-17\",\"Statement\":[{\"Effect\":\"Allow\",\"Action\":\"sts:AssumeRole\", \"Principal\":{ \"AWS\": \"642375522597\" }}]}");

            //Act
            var result = await facade.Execute(command);
            var result2 = await facade.Execute(new DeleteRoleCommand(result.RoleName));

            //Assert
            Assert.NotNull(result);
            Assert.Equal(roleName, result.RoleName);
            Assert.True(result2.IsCompletedSuccessfully);
        }
    }
}
