﻿using System;
using System.Net.Http;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps.Http.Request.Build.Definition
{
    public sealed class GetBuildDefinitionYamlRequest : ApiRequest
    {
        public GetBuildDefinitionYamlRequest(string organization, string project, int definitionId)
        {
            ApiVersion = "6.1-preview.1";
            Method = HttpMethod.Get;
            RequestUri = new Uri($"https://dev.azure.com/{organization}/{project}/_apis/build/definitions/{definitionId}/yaml?api-version={ApiVersion}");
        }
    }
}