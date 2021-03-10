using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures;
using Xunit;
using Xunit.Extensions.Ordering;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest
{
    [Order(1)]
    public class AwsFacadeTests : IClassFixture<AwsFacadeFixture>
    {
        private readonly AwsFacadeFixture _awsFacadeFixture;

        public AwsFacadeTests(AwsFacadeFixture awsFacadeFixture)
        {
            _awsFacadeFixture = awsFacadeFixture;
        }

        [Fact, Order(1)]
        public void CanRegisterProfile()
        {
            //Arrange
            using var sut = _awsFacadeFixture.Facade;
            var cmd = new RegisterProfileCommand(_awsFacadeFixture.TestProfile, _awsFacadeFixture.Options.AccessKey, _awsFacadeFixture.Options.SecretKey);

            //Act
            var result = sut.Execute(cmd);

            //Assert
            Assert.False(result.IsFaulted);
        }

        [Fact, Order(2)]
        public void CanUnregisterDefaultProfile()
        {
            //Arrange
            using var sut = _awsFacadeFixture.Facade;
            var cmd = new UnregisterProfileCommand(_awsFacadeFixture.TestProfile.Name);

            //Act
            var result = sut.Execute(cmd);

            //Assert
            Assert.False(result.IsFaulted);
        }
    }
}
