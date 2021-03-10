using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest.Fixtures;
using Xunit;
using Xunit.Extensions.Ordering;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.IntegrationTest
{
    [Order(1)]
    public class AwsFacadeTests : IClassFixture<AwsFacadeFixture>
    {
        private readonly AwsFacadeFixture _fixture;

        public AwsFacadeTests(AwsFacadeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact, Order(1)]
        public void CanRegisterProfile()
        {
            //Arrange
            using var sut = _fixture.Facade;
            var cmd = new RegisterProfileCommand(_fixture.TestProfile, _fixture.Options.AccessKey, _fixture.Options.SecretKey);

            //Act
            var result = sut.Execute(cmd);

            //Assert
            Assert.False(result.IsFaulted);
        }

        [Fact, Order(2)]
        public void CanUnregisterDefaultProfile()
        {
            //Arrange
            using var sut = _fixture.Facade;
            var cmd = new UnregisterProfileCommand(_fixture.TestProfile.Name);

            //Act
            var result = sut.Execute(cmd);

            //Assert
            Assert.False(result.IsFaulted);
        }
    }
}
