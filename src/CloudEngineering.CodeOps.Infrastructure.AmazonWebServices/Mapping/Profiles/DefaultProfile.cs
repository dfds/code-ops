using Amazon.CostExplorer.Model;
using Amazon.SimpleSystemsManagement.Model;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using CostJanitor.Infrastructure.CostProviders.Aws.Mapping.Converters;

namespace CostJanitor.Infrastructure.CostProviders.Aws.Mapping.Profiles
{
    public sealed class DefaultProfile : AutoMapper.Profile
    {
        public DefaultProfile()
        {
            CreateMap<GetCostAndUsageResponse, CostDto>()
            .ConvertUsing<GetCostAndUsageResponseToCostDto>();

            CreateMap<GetParameterResponse, ParameterDto>()
            .ConvertUsing<GetParameterResponseToParameterDto>();
        }
    }
}
