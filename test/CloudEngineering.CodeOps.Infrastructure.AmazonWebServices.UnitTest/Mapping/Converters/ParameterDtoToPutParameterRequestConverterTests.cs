using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Mapping.Converters;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Mapping.Converters
{
    public class ParameterDtoToPutParameterRequestConverterTests
    {
        [Fact]
        public void CanConvert()
        {
            //Arrange
            var sut = new ParameterDtoToPutParameterRequestConverter();
            var paramDto = new ParameterDto()
            {
                Name = "param",
                ParamType = "simple",
                Overwrite = true,
                Value = "value"
            };

            //Act
            var result = sut.Convert(paramDto, null, null);

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(result.Name, paramDto.Name);
            Assert.Equal(result.Type.Value, paramDto.ParamType);
            Assert.Equal(result.Overwrite, paramDto.Overwrite);
            Assert.Equal(result.Value, paramDto.Value);
        }
    }
}
