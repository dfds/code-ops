﻿using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Build;
using System.Net.Http;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Http.Request.Build
{
    public class GetBuildRequestTests
    {
        [Fact]
        public void CanBeConstructed()
        {
            //Arrange
            GetBuildRequest sut;

            //Act
            sut = new GetBuildRequest("my-org", "my-project", 1);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal("6.1-preview.6", sut.ApiVersion);
            Assert.Equal(HttpMethod.Get, sut.Method);
        
            Assert.Equal("https://dev.azure.com/my-org/my-project/_apis/build/1?api-version=6.1-preview.6", sut.RequestUri.AbsoluteUri);
        }
    }
}