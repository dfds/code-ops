using CloudEngineering.CodeOps.Security.Policies.Policies.All;

namespace CloudEngineering.CodeOps.Security.Policies.Requirements
{
    public sealed class ReadAccessRequirement : AccessRequirement
    {
        public ReadAccessRequirement() => AccessRequirementClaimName = ReadAccessPolicy.PolicyName;
    }
}
