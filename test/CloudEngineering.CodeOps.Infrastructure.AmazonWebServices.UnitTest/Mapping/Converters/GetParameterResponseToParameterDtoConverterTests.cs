using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Mapping.Converters;
using Moq;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Mapping.Converters
{
    public class GetParameterResponseToParameterDtoConverterTests
    {
        [Fact]
        public void CanConvert()
        {
            //Arrange
            var mockMapper = new Mock<IMapper>();
            var fakeResponse = new GetParameterResponse()
            {
                Parameter = new Parameter()
                {
                    Name = "name",
                    Type = new ParameterType("type"),
                    Version = 1,
                    Value = "value"
                }
            };
            var fakeDto = new ParameterDto()
            {
                Name = fakeResponse.Parameter.Name,
                ParamType = fakeResponse.Parameter.Type.Value,
                Version = fakeResponse.Parameter.Version,
                Value = fakeResponse.Parameter.Value
            };

            mockMapper.Setup(o => o.Map(It.IsAny<Parameter>(), It.IsAny<ParameterDto>())).Returns(fakeDto);

            var sut = new GetParameterResponseToParameterDtoConverter(mockMapper.Object);
            
            //Act
            var result = sut.Convert(fakeResponse, null, null);

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(fakeResponse.Parameter.Name, result.Name);
            Assert.Equal(fakeResponse.Parameter.Type.Value, result.ParamType);
            Assert.Equal(fakeResponse.Parameter.Version, result.Version);
            Assert.Equal(fakeResponse.Parameter.Value, result.Value);
        }
    }
}
