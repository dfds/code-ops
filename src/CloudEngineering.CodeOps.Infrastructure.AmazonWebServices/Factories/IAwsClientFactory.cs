using Amazon.Runtime;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories
{
    public interface IAwsClientFactory
    {
        T Create<T>(IAwsProfile assumeProfile = default) where T : IAmazonService;
    }
}
