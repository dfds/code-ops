using CloudEngineering.CodeOps.Security.Policies.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace CloudEngineering.CodeOps.Security.Policies
{
    public static class DependencyInjection
    {
        public static void AddSecurityPolicies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, AccessRequirementHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, DefaultAuthorizationPolicyProvider>();
        }
    }
}
