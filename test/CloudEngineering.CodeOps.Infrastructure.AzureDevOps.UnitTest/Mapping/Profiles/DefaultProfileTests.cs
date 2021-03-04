using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Mapping.Profiles;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Mapping.Profiles
{
    public class DefaultProfileTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            DefaultProfile sut;

            //Act
            sut = new DefaultProfile();

            //Assert
            Assert.NotNull(sut);
        }
    }
}
