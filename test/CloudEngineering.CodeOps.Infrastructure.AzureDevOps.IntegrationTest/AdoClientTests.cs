using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.IntegrationTest.Fixtures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.IntegrationTest
{
    public class AdoClientTests : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _fixture;

        public AdoClientTests(ConfigurationFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CanGetProjects()
        {
            //Arrange
            var options = new AdoClientOptions()
            {
                ClientSecret = _fixture.Configuration.GetValue<string>("AdoClient:ClientAccessToken"),
                Issuer = _fixture.Configuration.GetValue<Uri>("AdoClient:Issuer"),
                RedirectUri = _fixture.Configuration.GetValue<Uri>("AdoClient:RedirectUri")                
            };

            var sut = new AdoClient(Options.Create(options));

            //Act
            var projects = await sut.GetProjects("dfds");

            //Assert
            Assert.NotNull(projects);
            Assert.True(projects.Any());
        }
    }
}
