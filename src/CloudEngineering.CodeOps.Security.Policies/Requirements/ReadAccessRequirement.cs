namespace CloudEngineering.CodeOps.Security.Policies.Requirements
{
    public sealed class ReadAccessRequirement : AccessRequirement
    {
        public ReadAccessRequirement() => AccessRequirementClaimName = "Dfds.All.Read";
    }
}
