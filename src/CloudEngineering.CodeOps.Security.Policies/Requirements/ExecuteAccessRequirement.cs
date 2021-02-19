using CloudEngineering.CodeOps.Security.Policies.Policies.All;

namespace CloudEngineering.CodeOps.Security.Policies.Requirements
{
    public sealed class ExecuteAccessRequirement : AccessRequirement
    {
        public ExecuteAccessRequirement() => AccessRequirementClaimName = ExecuteAccessPolicy.PolicyName;
    }
}
