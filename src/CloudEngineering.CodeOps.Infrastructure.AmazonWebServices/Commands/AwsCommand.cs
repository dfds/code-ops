using CloudEngineering.CodeOps.Abstractions.Commands;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands
{
    public abstract class AwsCommand<TResult> : ICommand<TResult>
    {
        public IAwsProfile Impersonate
        {
            get;
            init;
        }
    }
}
