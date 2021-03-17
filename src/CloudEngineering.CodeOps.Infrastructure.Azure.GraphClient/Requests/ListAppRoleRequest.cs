using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.Requests
{
    public sealed class ListAppRoleRequest : HttpRequestMessage
    {
        public ListAppRoleRequest(string principalIdOrUserPrincipalName)
        {
            Method = HttpMethod.Get;
            RequestUri = new Uri($"https://graph.microsoft.com/v1.0/users/{principalIdOrUserPrincipalName}/appRoleAssignments");
        }
    }
}
