using CloudEngineering.CodeOps.Security.Policies.Requirements;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Security.Policies.Policies
{
    public class DefaultAuthorizationPolicyProviderTests
    {
        [Fact]
        public async Task DefaultAuthorizationPolicyProviderCanResolvePolicies() 
        { 
            //Arrange
            var options = Options.Create(new AuthorizationOptions());
            var sut = new DefaultAuthorizationPolicyProvider(options);

            //Act
            var readPolicy = await sut.GetPolicyAsync("dfds.all.read");
            var writePolicy = await sut.GetPolicyAsync("dfds.all.write");
            var executePolicy = await sut.GetPolicyAsync("dfds.all.execute");
            var fullPolicy = await sut.GetPolicyAsync("dfds.all.full");

            //Assert
            Assert.Contains(readPolicy.AuthenticationSchemes, (schema) => schema == CookieAuthenticationDefaults.AuthenticationScheme);
            Assert.Contains(readPolicy.Requirements, (requirement) => requirement is ReadAccessRequirement);
            Assert.Contains(writePolicy.AuthenticationSchemes, (schema) => schema == CookieAuthenticationDefaults.AuthenticationScheme);
            Assert.Contains(writePolicy.Requirements, (requirement) => requirement is WriteAccessRequirement);
            Assert.Contains(executePolicy.AuthenticationSchemes, (schema) => schema == CookieAuthenticationDefaults.AuthenticationScheme);
            Assert.Contains(executePolicy.Requirements, (requirement) => requirement is ExecuteAccessRequirement);
            Assert.Contains(fullPolicy.AuthenticationSchemes, (schema) => schema == CookieAuthenticationDefaults.AuthenticationScheme);
            Assert.Contains(fullPolicy.Requirements, (requirement) => requirement is ReadAccessRequirement);
            Assert.Contains(fullPolicy.Requirements, (requirement) => requirement is WriteAccessRequirement);
            Assert.Contains(fullPolicy.Requirements, (requirement) => requirement is ExecuteAccessRequirement);
        }
    }
}
