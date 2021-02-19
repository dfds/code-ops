using CloudEngineering.CodeOps.Abstractions.Commands;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands
{
    public abstract class AwsCommand<TResult> : ICommand<TResult> where TResult : Task
    {
        public IAwsProfile Impersonate
        {
            get;
            init;
        }
    }
}
