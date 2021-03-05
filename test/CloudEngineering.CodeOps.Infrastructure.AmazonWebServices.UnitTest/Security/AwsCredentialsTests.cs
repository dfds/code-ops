using Amazon.Runtime;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.UnitTest.Security
{
    public class AwsCredentialsTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            var sut = new AwsCredentials("access", "secret", "token");

            //Act
            var hash = sut.GetHashCode();

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(hash, sut.GetHashCode());
            Assert.Equal("access", sut.AccessKey);
            Assert.Equal("secret", sut.SecretKey);
            Assert.Equal("token", sut.Token);
        }

        [Fact]
        public void CanCastToAWSCredentials()
        {
            //Arrange
            var sut = new AwsCredentials("access", "secret", "token");

            //Act
            var convertedCreds = ((AWSCredentials)sut).GetCredentials();

            //Assert
            Assert.NotNull(convertedCreds);
            Assert.Equal("access", convertedCreds.AccessKey);
            Assert.Equal("secret", convertedCreds.SecretKey);
            Assert.Equal("token", convertedCreds.Token);
        }

        [Fact]
        public void CanCastFromImmutableCredentials()
        {
            //Arrange
            var sut = new ImmutableCredentials("access", "secret", "token");

            //Act
            var convertedCreds = (AwsCredentials)sut;

            //Assert
            Assert.NotNull(convertedCreds);
            Assert.Equal("access", convertedCreds.AccessKey);
            Assert.Equal("secret", convertedCreds.SecretKey);
            Assert.Equal("token", convertedCreds.Token);
        }
    }
}
