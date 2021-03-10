using Amazon.Runtime;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter
{
    public sealed class AddOrUpdateParameterCommandHandler : AwsCommandHandler<AddOrUpdateParameterCommand, ParameterDto>
    {
        public AddOrUpdateParameterCommandHandler(IAwsClientFactory awsClientFactory) : base(awsClientFactory)
        {
        }

        public async override Task<ParameterDto> Handle(AddOrUpdateParameterCommand command, CancellationToken cancellationToken = default)
        {
            using var client = _awsClientFactory.Create<AmazonSimpleSystemsManagementClient>(command.AssumeProfile);

            ParameterDto result = null;

            var request = new PutParameterRequest()
            {
                Name = command.Parameter.Name,
                Value = command.Parameter.Value,
                Type = command.Parameter.ParamType,
                Overwrite = command.Parameter.Overwrite,
                Tags = command.Parameter.Tags?.Select(kv => new Tag { Key = kv.Key, Value = kv.Value }).ToList()
            };

            try
            {
                var response = await client.PutParameterAsync(request, cancellationToken);

                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = new ParameterDto
                    {
                        Name = command.Parameter.Name,
                        Overwrite = command.Parameter.Overwrite,
                        Value = command.Parameter.Value,
                        Version = command.Parameter.Version,
                        Tags = command.Parameter.Tags,
                        ParamType = command.Parameter.ParamType
                    };
                }
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return result;
        }
    }
}