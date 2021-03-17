using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Profile;
using System.Net.Http;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.Http.Request.Profile
{
    public class GetProfileRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            GetProfileRequest sut;

            //Act
            sut = new GetProfileRequest("my-profile-id");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.3", sut.ApiVersion);
            Assert.Equal(HttpMethod.Get, sut.Method);
            Assert.Equal("https://app.vssps.visualstudio.com/_apis/profile/profiles/my-profile-id?api-version=6.1-preview.3", sut.RequestUri.AbsoluteUri);
        }
    }
}