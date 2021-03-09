using AutoMapper;
using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Build;
using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Mapping.Converters;
using Moq;
using Xunit;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.UnitTest.Mapping.Converters
{
    public class AdoDtoToAggregateRootConverterTests
    {
        [Fact]
        public void CanConvert()
        {
            //Arrange
            var mockMapper = new Mock<IMapper>();
            var mockAggregate = new Mock<IAggregateRoot>();

            mockMapper.Setup(m => m.Map<IAggregateRoot>(It.IsAny<AdoDto>())).Returns(mockAggregate.Object);

            ITypeConverter<AdoDto, IAggregateRoot> sut = new AdoDtoToAggregateRootConverter(mockMapper.Object);

            //Act
            var result = sut.Convert(new BuildDto(), mockAggregate.Object, null);
            var result2 = sut.Convert(new BuildDto(), null, null);

            //Assert
            Assert.NotNull(sut);
            Assert.NotNull(result);
            Assert.Equal(result, mockAggregate.Object);
            Assert.Equal(result, result2);

            Mock.VerifyAll(mockMapper, mockAggregate);
        }
    }
}
