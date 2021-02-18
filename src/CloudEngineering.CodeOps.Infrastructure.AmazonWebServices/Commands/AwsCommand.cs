using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands
{
    public abstract class AwsCommand<T> : IAwsCommand<T>
    {
        protected IAwsClientFactory ClientFactory
        {
            get;
        }

        public IAwsProfile Impersonate
        {
            get;
            internal set;
        }

        protected AwsCommand(IAwsClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }
    }
}
