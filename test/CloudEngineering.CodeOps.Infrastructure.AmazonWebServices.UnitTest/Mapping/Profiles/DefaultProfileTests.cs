using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Mapping.Profiles;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.UnitTest.Mapping.Profiles
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
