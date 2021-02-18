using CloudEngineering.CodeOps.Abstractions.Commands;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands
{
    public interface IAwsCommand<T> : ICommand<T>
    {
    }
}
