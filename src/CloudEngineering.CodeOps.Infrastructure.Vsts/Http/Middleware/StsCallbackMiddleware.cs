using CloudEngineering.CodeOps.Infrastructure.Vsts.Caching;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CloudEngineering.CodeOps.Infrastructure.Vsts.DataTransferObjects.Shared;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts.Http.Middleware
{
    public sealed class StsCallbackMiddleware : IMiddleware
    {
        private readonly IMemoryCache _cache;
        private readonly IOptions<VstsClientOptions> _vstsOptions;
        private readonly HttpClient _httpClient;

        public StsCallbackMiddleware(IMemoryCache cache, IOptions<VstsClientOptions> options, HttpClient client)
        {
            _cache = cache;
            _vstsOptions = options;
            _httpClient = client;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path.Value == _vstsOptions.Value.RedirectUri.AbsolutePath)
            {
                if (!context.Request.QueryString.HasValue || !context.Request.QueryString.Value.Contains("code"))
                {
                    throw new Exception("Missing code query param in oauth2 callback");
                }

                var formData = new Dictionary<string, string>();
                var code = QueryHelpers.ParseQuery(context.Request.QueryString.Value)["code"];

                formData.Add("client_assertion", _vstsOptions.Value.ClientSecret);
                formData.Add("client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer");
                formData.Add("assertion", code);
                formData.Add("grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer");
                formData.Add("redirect_uri", _vstsOptions.Value.RedirectUri.AbsoluteUri);

                var stsResponse = await _httpClient.PostAsync(_vstsOptions.Value.TokenService.AbsoluteUri, new FormUrlEncodedContent(formData));
                var stsResponseData = await stsResponse.Content.ReadAsStringAsync();
                var stsPayload = JsonSerializer.Deserialize<StsDto>(stsResponseData);
                var tokenHandler = new JwtSecurityTokenHandler();

                if (tokenHandler.CanReadToken(stsPayload.AccessToken))
                {
                    var token = tokenHandler.ReadJwtToken(stsPayload.AccessToken);

                    if (double.TryParse(stsPayload.ExpiresIn, out double expires))
                    {
                        _cache.Set(CacheKeys.VstsClientSecretKey, token, TimeSpan.FromSeconds(expires));
                    }
                }
            }

            await next(context);
        }
    }
}
