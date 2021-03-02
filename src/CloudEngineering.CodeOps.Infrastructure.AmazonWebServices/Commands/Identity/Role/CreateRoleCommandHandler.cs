using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Role;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed class CreateRoleCommandHandler : AwsCommandHandler<CreateRoleCommand, RoleDto>
    {
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IAwsClientFactory awsClientFactory, IMapper mapper) : base(awsClientFactory)
        {
            _mapper = mapper;
        }

        public async override Task<RoleDto> Handle(CreateRoleCommand command, CancellationToken cancellationToken = default)
        {
            using var client = _awsClientFactory.Create<AmazonIdentityManagementServiceClient>(command.AssumeProfile);

            var request = new CreateRoleRequest()
            {
                RoleName = command.RoleName,
                AssumeRolePolicyDocument = command.PolicyDocument,
                Description = command.Description,
                Tags = command.Tags?.Select(tag => new Tag() { Key = tag.Key, Value = tag.Value }).ToList()
            };

            RoleDto result;

            try
            {
                result = _mapper.Map<RoleDto>((await client.CreateRoleAsync(request, cancellationToken)).Role);
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return result;
        }
    }
}