using Amazon.CostExplorer.Model;
using Amazon.SimpleSystemsManagement.Model;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Mapping.Converters;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Mapping.Profiles
{
    public sealed class DefaultProfile : AutoMapper.Profile
    {
        public DefaultProfile()
        {
            CreateMap<GetCostAndUsageResponse, CostDto>()
            .ConvertUsing<GetCostAndUsageResponseToCostDtoConverter>();

            CreateMap<GetParameterResponse, ParameterDto>()
            .ConvertUsing<GetParameterResponseToParameterDtoConverter>();
        }
    }
}
