using CloudEngineering.CodeOps.Security.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Security.Policies.Handlers
{
    public class AccessRequirementHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var requirement in pendingRequirements)
            {
                switch (requirement)
                {
                    case AccessRequirement accessRequirement:
                        if (context.User.HasClaim(claim => claim.Value.Equals(accessRequirement.AccessRequirementClaimName)))
                        {
                            context.Succeed(requirement);
                        }

                        break;

                    default:
                        break;
                }
            }

            return Task.CompletedTask;
        }
    }
}
