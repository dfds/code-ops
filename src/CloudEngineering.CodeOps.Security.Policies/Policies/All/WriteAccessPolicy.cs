using CloudEngineering.CodeOps.Security.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace CloudEngineering.CodeOps.Security.Policies.Policies.All
{
    public sealed class WriteAccessPolicy : AuthorizationPolicy
    {
        public const string PolicyName = "dfds.all.write";

        public WriteAccessPolicy(IEnumerable<string> authenticationSchemes) : base(new IAuthorizationRequirement[] { new WriteAccessRequirement() }, authenticationSchemes)
        {
        }
    }
}
