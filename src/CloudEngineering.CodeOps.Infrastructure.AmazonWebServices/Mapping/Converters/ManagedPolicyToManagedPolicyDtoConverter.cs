using Amazon.IdentityManagement.Model;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Mapping.Converters
{
    public class ManagedPolicyToManagedPolicyDtoConverter : ITypeConverter<ManagedPolicy, ManagedPolicyDto>
    {
        public ManagedPolicyDto Convert(ManagedPolicy source, ManagedPolicyDto destination, ResolutionContext context)
        {
            destination ??= new ManagedPolicyDto();

            destination.PolicyId = source.PolicyId;
            destination.PolicyName = source.PolicyName;
            destination.Arn = source.Arn;
            destination.Description = source.Description;
            destination.Path = source.Path;

            return destination;
        }
    }
}