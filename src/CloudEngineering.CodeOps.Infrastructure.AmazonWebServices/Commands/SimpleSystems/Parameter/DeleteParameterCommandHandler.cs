using Amazon.Runtime;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed class DeleteParameterCommandHandler : AwsCommandHandler<DeleteParameterCommand, Task>
   {
        public DeleteParameterCommandHandler(IAwsClientFactory awsClientFactory, IAwsProfile fallbackProfile = default) : base(awsClientFactory, fallbackProfile)
        { }

        public async override Task<Task> Handle(DeleteParameterCommand command, CancellationToken cancellationToken = default)
        {
            using var client = await _awsClientFactory.Create<AmazonSimpleSystemsManagementClient>(command.Impersonate ?? _fallbackProfile);

            var request = new DeleteParameterRequest
            {
                Name = command.ParamName
            };

            try
            {
                await client.DeleteParameterAsync(request, cancellationToken);
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return Task.CompletedTask;
        }
    }
}