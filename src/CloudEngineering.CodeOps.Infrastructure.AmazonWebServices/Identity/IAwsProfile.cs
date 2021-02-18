using System.Threading.Tasks;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity
{
    public interface IAwsProfile
    {
        string SourceProfile { get; }

        string Name { get; }

        string RoleArn { get; }

        Task<IAwsCredentials> GetCredentials();
    }

}
