using CloudEngineering.CodeOps.Security.Policies.Policies.All;

namespace CloudEngineering.CodeOps.Security.Policies.Requirements
{
    public sealed class WriteAccessRequirement : AccessRequirement
    {
        public WriteAccessRequirement() => AccessRequirementClaimName = WriteAccessPolicy.PolicyName;
    }
}
