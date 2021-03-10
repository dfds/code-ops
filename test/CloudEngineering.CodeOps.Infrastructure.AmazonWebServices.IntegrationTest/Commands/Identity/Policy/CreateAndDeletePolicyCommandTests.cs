using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Policy;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Commands.Identity.Policy
{
    public class CreateAndDeletePolicyCommandTests : IClassFixture<AwsFacadeFixture>
    {
        private readonly AwsFacadeFixture _fixture;

        public CreateAndDeletePolicyCommandTests(AwsFacadeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CanCreateAndDeletePolicy()
        {
            //Arrange
            var facade = _fixture.Facade;

            var policyName = Guid.NewGuid().ToString();
            var command = new CreatePolicyCommand(policyName, "{\"Version\": \"2012-10-17\",\"Statement\":[{\"Effect\":\"Allow\",\"Action\":\"s3: ListAllMyBuckets\",\"Resource\":\"arn:aws:s3:::*\"}]}");

            //Act
            var result = await facade.Execute(command);
            var result2 = await facade.Execute(new DeletePolicyCommand(result.Arn));

            //Assert
            Assert.NotNull(result);
            Assert.Equal(policyName, result.PolicyName);
            Assert.True(result2.IsCompletedSuccessfully);
        }
    }
}
