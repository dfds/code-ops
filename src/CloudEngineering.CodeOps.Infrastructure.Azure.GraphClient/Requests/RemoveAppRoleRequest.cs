using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.Requests
{
    public sealed class RemoveAppRoleRequest : HttpRequestMessage
    {
        public RemoveAppRoleRequest(string Id)
        {
            Method = HttpMethod.Delete;
            RequestUri = new Uri($"https://graph.microsoft.com/v1.0/users/{Id}/appRoleAssignments/{Id}");
        }
    }
}
