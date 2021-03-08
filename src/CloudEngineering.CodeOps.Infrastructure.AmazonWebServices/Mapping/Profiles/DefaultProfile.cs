using Amazon.CostExplorer.Model;
using Amazon.IdentityManagement.Model;
using Amazon.SimpleSystemsManagement.Model;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy;
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

            CreateMap<ParameterDto, PutParameterRequest>()
            .ConvertUsing<ParameterDtoToPutParameterRequestConverter>();

            CreateMap<PutParameterRequest, ParameterDto>()
            .ConvertUsing<ParameterDtoToPutParameterRequestConverter>();
            
            CreateMap<Parameter, ParameterDto>()
            .ConvertUsing<ParameterToParameterDtoConverter>();

            CreateMap<ManagedPolicy, ManagedPolicyDto>()
            .ConvertUsing<ManagedPolicyToManagedPolicyDtoConverter>();

            CreateMap<ManagedPolicyDto, ManagedPolicy>()
            .ConvertUsing<ManagedPolicyToManagedPolicyDtoConverter>();

        }
    }
}
