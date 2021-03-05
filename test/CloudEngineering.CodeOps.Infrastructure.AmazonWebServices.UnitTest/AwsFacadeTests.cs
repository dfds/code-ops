using MediatR;
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
            var mockMediator = new Mock<IMediator>();
            var sut = new AwsFacade(mockMediator.Object);

            //Act
            var hash = sut.GetHashCode();

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(hash, sut.GetHashCode());
        }
    }
}
