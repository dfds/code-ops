using CloudEngineering.CodeOps.Security.Policies.Handlers;
using CloudEngineering.CodeOps.Security.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Xunit;

namespace CloudEngineering.CodeOps.Security.Policies.UnitTest.Handlers
{
    public class AccessRequirementHandlerTests
    {
        [Fact]
        public void CanHandleDfdsAccessRequirements()
        {
            //Arrange
            var fakeRequirements = new AccessRequirement[] { new ExecuteAccessRequirement(), new ReadAccessRequirement(), new WriteAccessRequirement() };
            var fakeIdentity = new ClaimsIdentity(new[] { new Claim("dfds.access", "dfds.all.execute"), new Claim("dfds.access", "dfds.all.read"), new Claim("dfds.access", "dfds.all.write") });
            var fakePrincipal = new ClaimsPrincipal(fakeIdentity);
            var fakeAuthorizationHandlerContext = new AuthorizationHandlerContext(fakeRequirements, fakePrincipal, null);
            var sut = new AccessRequirementHandler();

            //Act
            var task = sut.HandleAsync(fakeAuthorizationHandlerContext);

            //Assert
            Assert.True(task.IsCompletedSuccessfully);
            Assert.True(fakeAuthorizationHandlerContext.HasSucceeded);
        }
    }
}
