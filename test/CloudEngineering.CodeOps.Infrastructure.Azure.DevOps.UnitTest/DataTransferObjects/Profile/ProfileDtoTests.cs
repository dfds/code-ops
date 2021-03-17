using CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Profile;
using System;
using System.Text.Json;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.UnitTest.DataTransferObjects.Profile
{
    public class ProfileDtoTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            ProfileDto sut;

            //Act
            sut = new ProfileDto();

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void CanBeSerialized()
        {
            //Arrange
            var sut = new ProfileDto()
            {
                Id = Guid.NewGuid(),
                Name = "MyName",
                Alias = Guid.NewGuid(),
                Email = "myemail@dfds.com"
            };

            //Act
            var payload = JsonSerializer.Serialize(sut, new JsonSerializerOptions { IgnoreNullValues = true });

            //Assert
            Assert.NotNull(JsonDocument.Parse(payload));
        }

        [Fact]
        public void CanBeDeserialized()
        {
            //Arrange
            ProfileDto sut;

            //Act
            sut = JsonSerializer.Deserialize<ProfileDto>("{\"id\":\"3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1\",\"displayName\":\"MyName\",\"publicAlias\":\"3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1\",\"emailAddress\":\"myemail@dfds.com\"}");

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(Guid.Parse("3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1"), sut.Id);
            Assert.Equal("MyName", sut.Name);
            Assert.Equal(Guid.Parse("3ededfb7-5b60-49d9-9c47-80bbf8f2dcb1"), sut.Alias);
            Assert.Equal("myemail@dfds.com", sut.Email);
        }
    }
}