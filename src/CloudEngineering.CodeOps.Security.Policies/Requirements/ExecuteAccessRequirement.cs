namespace CloudEngineering.CodeOps.Security.Policies.Requirements
{
    public sealed class ExecuteAccessRequirement : AccessRequirement
    {
        public ExecuteAccessRequirement() => AccessRequirementClaimName = "Dfds.All.Execute";
    }
}
