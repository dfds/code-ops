﻿using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Build;
using System.Net.Http;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Http.Request.Build
{
    public class DeleteBuildRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            DeleteBuildRequest sut;

            //Act
            sut = new DeleteBuildRequest("my-org", "my-project", 1);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.6", sut.ApiVersion);
            Assert.Equal(HttpMethod.Delete, sut.Method);

            Assert.Equal("https://dev.azure.com/my-org/my-project/_apis/build/1?api-version=6.1-preview.6", sut.RequestUri.AbsoluteUri);
        }
    }
}