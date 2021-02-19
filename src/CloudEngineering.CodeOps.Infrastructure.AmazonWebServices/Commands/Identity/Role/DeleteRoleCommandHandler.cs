using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed class DeleteRoleCommandHandler : AwsCommandHandler<DeleteRoleCommand, Task>
   {
        public DeleteRoleCommandHandler(IAwsClientFactory awsClientFactory, IAwsProfile fallbackProfile = default) : base(awsClientFactory, fallbackProfile)
        { }

        public async override Task<Task> Handle(DeleteRoleCommand command, CancellationToken cancellationToken = default)
        {
            using var client = await _awsClientFactory.Create<AmazonIdentityManagementServiceClient>(command.Impersonate ?? _fallbackProfile);

            var request = new DeleteRoleRequest()
            {
                RoleName = command.RoleName
            };

            try
            {
                await client.DeleteRoleAsync(request, cancellationToken);
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return Task.CompletedTask;
        }
    }
}