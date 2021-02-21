using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Policy
{
    public sealed class CreatePolicyCommandHandler : AwsCommandHandler<CreatePolicyCommand, ManagedPolicyDto>
    {
        private readonly IMapper _mapper;

        public CreatePolicyCommandHandler(IAwsClientFactory awsClientFactory, IMapper mapper, IAwsProfile fallbackProfile = default) : base(awsClientFactory, fallbackProfile)
        {
            _mapper = mapper;
        }

        public async override Task<ManagedPolicyDto> Handle(CreatePolicyCommand command, CancellationToken cancellationToken = default)
        {
            using var client = await _awsClientFactory.Create<AmazonIdentityManagementServiceClient>(command.Impersonate ?? _fallbackProfile);

            var request = new CreatePolicyRequest()
            {
                PolicyName = command.PolicyName,
                PolicyDocument = command.PolicyDocument
            };

            ManagedPolicyDto result;

            try
            {
                result = _mapper.Map<ManagedPolicyDto>((await client.CreatePolicyAsync(request, cancellationToken)).Policy);
            }
            catch (AmazonServiceException e)
            {
                throw new AwsFacadeException(e.Message, e);
            }

            return result;
        }
    }
}