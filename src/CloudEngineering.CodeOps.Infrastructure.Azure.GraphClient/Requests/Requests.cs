using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.DataTransferObjects;

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

    public sealed class AddAppRoleRequest : HttpRequestMessage
    {
        public AddAppRoleRequest(string principalId, AzureAppRoleAssignment azureAppRoleAssignment)
        {
            Content = new StringContent(JsonSerializer.Serialize(azureAppRoleAssignment), Encoding.UTF8, "application/json");
            Method = HttpMethod.Post;
            RequestUri = new Uri($"https://graph.microsoft.com/v1.0/users/{principalId}/appRoleAssignments");
        }
    }

    public sealed class RemoveAppRoleRequest : HttpRequestMessage
    {
        public RemoveAppRoleRequest(string Id)
        {
            Method = HttpMethod.Delete;
            RequestUri = new Uri($"https://graph.microsoft.com/v1.0/users/{Id}/appRoleAssignments/{Id}");
        }
    }
}
