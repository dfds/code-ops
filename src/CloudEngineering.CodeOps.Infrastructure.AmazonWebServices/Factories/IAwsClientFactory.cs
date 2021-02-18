using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories
{
    public interface IAwsClientFactory
    {
        Task<T> Create<T>(IAwsProfile credentialSource = default) where T : class;
    }
}
