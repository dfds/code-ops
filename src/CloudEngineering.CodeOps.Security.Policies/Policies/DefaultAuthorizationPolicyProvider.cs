using CloudEngineering.CodeOps.Security.Policies.Policies.All;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Security.Policies.Policies
{
    public class DefaultAuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        private readonly string[] _authenticationSchemas = { CookieAuthenticationDefaults.AuthenticationScheme };
        private readonly Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider _backupPolicyProvider;

        public DefaultAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options, string[] authenticationSchemas = default)
        {
            _authenticationSchemas = authenticationSchemas ?? _authenticationSchemas;
            _backupPolicyProvider = new Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider(options);
        }

        public async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            AuthorizationPolicy policy = policyName switch
            {
                WriteAccessPolicy.PolicyName => new WriteAccessPolicy(_authenticationSchemas),
                ExecuteAccessPolicy.PolicyName => new ExecuteAccessPolicy(_authenticationSchemas),
                ReadAccessPolicy.PolicyName => new ReadAccessPolicy(_authenticationSchemas),
                FullAccessPolicy.PolicyName => new FullAccessPolicy(_authenticationSchemas),
                _ => await _backupPolicyProvider.GetPolicyAsync(policyName),
            };

            return policy;
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => Task.FromResult(new AuthorizationPolicyBuilder(_authenticationSchemas).RequireAuthenticatedUser().Build());

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => Task.FromResult<AuthorizationPolicy>(null);
    }
}
