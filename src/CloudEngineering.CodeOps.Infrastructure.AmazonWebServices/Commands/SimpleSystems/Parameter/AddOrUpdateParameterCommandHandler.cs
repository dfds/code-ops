using Amazon.Runtime;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed class AddOrUpdateParameterCommandHandler : AwsCommandHandler<AddOrUpdateParameterCommand, ParameterDto>
    {
        private readonly IMapper _mapper;

        public AddOrUpdateParameterCommandHandler(IAwsClientFactory awsClientFactory, IMapper mapper) : base(awsClientFactory)
        {
            _mapper = mapper;
        }

        public async override Task<ParameterDto> Handle(AddOrUpdateParameterCommand command, CancellationToken cancellationToken = default)
        {
            using var client = _awsClientFactory.Create<AmazonSimpleSystemsManagementClient>(command.AssumeProfile);
                        
            ParameterDto result;

            var request = _mapper.Map<PutParameterRequest>(command.Parameter);

            try
            {
                result = _mapper.Map<ParameterDto>(await client.PutParameterAsync(request, cancellationToken));
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return result;
        }
    }
}