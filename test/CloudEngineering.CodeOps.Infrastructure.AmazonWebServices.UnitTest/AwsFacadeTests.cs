using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using MediatR;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.UnitTest
{
    public class AwsFacadeTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            var fakeOptions = new AwsFacadeOptions()
            {
                Impersonate = new AwsProfile() { Name = "testing" },
                AccessKey = "testing_access_key",
                SecretKey = "testing_secret_key",
                ProfilesLocation = ".\\awsfacade"
            };

            var mockMediator = new Mock<IMediator>();
            using var sut = new AwsFacade(Options.Create(fakeOptions), mockMediator.Object);

            //Act
            var hash = sut.GetHashCode();

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(hash, sut.GetHashCode());
        }
    }
}
