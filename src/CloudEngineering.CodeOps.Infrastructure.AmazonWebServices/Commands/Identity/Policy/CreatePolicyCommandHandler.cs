using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Policy
{
    public sealed class CreatePolicyCommandHandler : AwsCommandHandler<CreatePolicyCommand, ManagedPolicyDto>
    {
        private readonly IMapper _mapper;

        public CreatePolicyCommandHandler(IAwsClientFactory awsClientFactory, IMapper mapper) : base(awsClientFactory)
        {
            _mapper = mapper;
        }

        public async override Task<ManagedPolicyDto> Handle(CreatePolicyCommand command, CancellationToken cancellationToken = default)
        {
            using var client = _awsClientFactory.Create<AmazonIdentityManagementServiceClient>(command.AssumeProfile);

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