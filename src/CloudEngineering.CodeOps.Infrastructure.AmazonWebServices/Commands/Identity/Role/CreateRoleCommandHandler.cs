using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed class CreateRoleCommandHandler : AwsCommandHandler<CreateRoleCommand, Task>
   {
        public CreateRoleCommandHandler(IAwsClientFactory awsClientFactory, IAwsProfile fallbackProfile = default) : base(awsClientFactory, fallbackProfile)
        { }

        public async override Task<Task> Handle(CreateRoleCommand command, CancellationToken cancellationToken = default)
        {
            using var client = await _awsClientFactory.Create<AmazonIdentityManagementServiceClient>(command.Impersonate ?? _fallbackProfile);

            var request = new CreateRoleRequest()
            {
                RoleName = command.RoleName,
                AssumeRolePolicyDocument = command.PolicyDocument,
                Description = command.Description,
                Tags = command.Tags?.Select(tag => new Tag() { Key = tag.Key, Value = tag.Value }).ToList()
            };

            try
            {
                await client.CreateRoleAsync(request);
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return Task.CompletedTask;
        }
    }
}