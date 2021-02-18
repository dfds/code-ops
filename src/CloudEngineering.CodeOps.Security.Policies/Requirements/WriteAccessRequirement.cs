namespace CloudEngineering.CodeOps.Security.Policies.Requirements
{
    public sealed class WriteAccessRequirement : AccessRequirement
    {
        public WriteAccessRequirement() => AccessRequirementClaimName = "Dfds.All.Write";
    }
}
