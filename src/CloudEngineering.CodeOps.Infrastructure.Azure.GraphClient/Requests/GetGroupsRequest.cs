using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.Requests
{
    public sealed class GetGroupsRequest : HttpRequestMessage
    {
        public GetGroupsRequest(string filter = default, string select = "id,displayName")
        {
            Method = HttpMethod.Get;
            RequestUri = new Uri($"https://graph.microsoft.com/v1.0/groups?$filter={filter}");
            // ?$count=true&$filter={filter}&$select={select}
        }
    }
}
