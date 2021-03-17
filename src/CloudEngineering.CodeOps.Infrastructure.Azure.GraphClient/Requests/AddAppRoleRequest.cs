using CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.DataTransferObjects;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.Requests
{
    public sealed class AddAppRoleRequest : HttpRequestMessage
    {
        public AddAppRoleRequest(string principalId, AzureAppRoleAssignmentDto azureAppRoleAssignment)
        {
            Content = new StringContent(JsonSerializer.Serialize(azureAppRoleAssignment), Encoding.UTF8, "application/json");
            Method = HttpMethod.Post;
            RequestUri = new Uri($"https://graph.microsoft.com/v1.0/users/{principalId}/appRoleAssignments");
        }
    }
}
