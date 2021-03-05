using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security;
using System.IO;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.UnitTest.Security
{
    public class AwsCredentialResolverTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            var sut = new AwsCredentialResolver(Directory.GetCurrentDirectory());

            //Act
            var hash = sut.GetHashCode();

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(hash, sut.GetHashCode());
        }

        [Fact]
        public void CanResolve()
        {
            //Arrange
            var sut = new AwsCredentialResolver(Directory.GetCurrentDirectory());

            //Act
            var creds = sut.Resolve(new AwsProfile());

            //Assert
            Assert.Null(creds);
        }
    }
}
