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

        public DefaultAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            _backupPolicyProvider = new Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider(options);
        }

        public async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            AuthorizationPolicy policy;

            switch (policyName)
            {
                case WriteAccessPolicy.PolicyName:
                    policy = new WriteAccessPolicy(_authenticationSchemas);

                    break;
                case ExecuteAccessPolicy.PolicyName:
                    policy = new ExecuteAccessPolicy(_authenticationSchemas);

                    break;
                case ReadAccessPolicy.PolicyName:
                    policy = new ReadAccessPolicy(_authenticationSchemas);

                    break;
                case FullAccessPolicy.PolicyName:
                    policy = new FullAccessPolicy(_authenticationSchemas);

                    break;
                default:
                    policy = await _backupPolicyProvider.GetPolicyAsync(policyName);

                    break;
            }

            return policy;
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => Task.FromResult(new AuthorizationPolicyBuilder(_authenticationSchemas).RequireAuthenticatedUser().Build());

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => Task.FromResult<AuthorizationPolicy>(null);
    }
}
