using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public interface IAwsCredentialResolver
    {
        AwsCredentials Resolve(IAwsProfile profile);
    }
}
