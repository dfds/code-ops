using CloudEngineering.CodeOps.Infrastructure.AzureDevOps.DataTransferObjects.Release;
using System;
using System.Net.Http;
using System.Text.Json;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps.Http.Request.Release
{
    public sealed class UpdateReleaseRequest : ApiRequest
    {
        public UpdateReleaseRequest(string organization, string project, ReleaseDto release) : this(organization, project, release.Id)
        {
            Content = new StringContent(JsonSerializer.Serialize(release));
        }

        public UpdateReleaseRequest(string organization, string project, int releaseId)
        {
            ApiVersion = "6.1-preview.8";
            Method = HttpMethod.Put;
            RequestUri = new Uri($"https://vsrm.dev.azure.com/{organization}/{project}/_apis/release/releases/{releaseId}?api-version={ApiVersion}");
        }
    }
}
