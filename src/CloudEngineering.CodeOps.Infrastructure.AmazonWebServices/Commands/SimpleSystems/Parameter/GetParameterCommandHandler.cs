﻿using Amazon.Runtime;
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
    public sealed class GetParameterCommandHandler : AwsCommandHandler<GetParameterCommand, ParameterDto>
    {
        private readonly IMapper _mapper;

        public GetParameterCommandHandler(IAwsClientFactory awsClientFactory, IMapper mapper) : base(awsClientFactory)
        {
            _mapper = mapper;
        }

        public async override Task<ParameterDto> Handle(GetParameterCommand command, CancellationToken cancellationToken = default)
        {
            using var client = _awsClientFactory.Create<AmazonSimpleSystemsManagementClient>(command.AssumeProfile);

            var request = new GetParameterRequest
            {
                Name = command.Name
            };

            ParameterDto result;

            try
            {
                result = _mapper.Map<ParameterDto>(await client.GetParameterAsync(request, cancellationToken));
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return result;
        }
    }
}