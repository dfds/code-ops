using System.Threading.Tasks;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public interface IAwsCredentialResolver
    {
        Task<IAwsCredentials> Resolve(IAwsProfile profile = default, string roleSessionName = default);
    }
}
