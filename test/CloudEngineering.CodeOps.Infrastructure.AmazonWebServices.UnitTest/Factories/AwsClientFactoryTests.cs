using Amazon.CostExplorer;
using Amazon.IdentityManagement;
using Amazon.SimpleSystemsManagement;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using Microsoft.Extensions.Options;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Mapping.Converters
{
    public class AwsClientFactoryTests
    {
        private readonly IOptions<AwsFacadeOptions> _options = Options.Create(new AwsFacadeOptions()
        {
            Region = "eu-central-1",
            AccessKey = "AKIAZLEEQTESQSMXVVX5",
            SecretKey = "invalid"
        });

        [Fact]
        public void CanCreateAmazonCostExplorerClient()
        {
            //Arrange
            var sut = new AwsClientFactory(_options);

            //Act
            var result = sut.Create<AmazonCostExplorerClient>();

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(result.Config.RegionEndpoint.SystemName, _options.Value.Region);            
        }

        [Fact]
        public void CanCreateAmazonSimpleSystemsManagementClient()
        {
            //Arrange
            var sut = new AwsClientFactory(_options);

            //Act
            var result = sut.Create<AmazonSimpleSystemsManagementClient>();

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(result.Config.RegionEndpoint.SystemName, _options.Value.Region);
        }

        [Fact]
        public void CanCreateAmazonIdentityManagementServiceClient()
        {
            //Arrange
            var sut = new AwsClientFactory(_options);

            //Act
            var result = sut.Create<AmazonIdentityManagementServiceClient>();

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(result.Config.RegionEndpoint.SystemName, _options.Value.Region);
        }
    }
}
