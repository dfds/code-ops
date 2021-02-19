using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ADSync.Infrastructure.AWS.Commands.Identity
{
    public sealed class CreatePolicyCommandHandler : AwsCommandHandler<CreatePolicyCommand, Task>
   {
        public CreatePolicyCommandHandler(IAwsClientFactory awsClientFactory, IAwsProfile fallbackProfile = default) : base(awsClientFactory, fallbackProfile)
        { }

        public async override Task<Task> Handle(CreatePolicyCommand command, CancellationToken cancellationToken = default)
        {
            using var client = await _awsClientFactory.Create<AmazonIdentityManagementServiceClient>(command.Impersonate ?? _fallbackProfile);

            var request = new CreatePolicyRequest()
            {
                PolicyName = command.PolicyName,
                PolicyDocument = command.PolicyDocument
            };

            try
            {
                await client.CreatePolicyAsync(request);
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return Task.CompletedTask;
        }
    }
}