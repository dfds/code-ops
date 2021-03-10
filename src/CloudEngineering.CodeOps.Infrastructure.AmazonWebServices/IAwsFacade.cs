using CloudEngineering.CodeOps.Abstractions.Facade;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices
{
    public interface IAwsFacade : IFacade
    {
        void Connect();

        void Disconnect();
    }
}
