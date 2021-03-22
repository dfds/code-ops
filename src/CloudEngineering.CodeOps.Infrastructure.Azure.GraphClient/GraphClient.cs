using CloudEngineering.CodeOps.Abstractions.Protocols.Http;
using CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.DataTransferObjects;
using CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.Requests;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient
{
    public sealed class GraphClient : RestClient, IGraphClient
    {
        private readonly GraphClientOptions _options;

        public GraphClient(IOptions<GraphClientOptions> options = default) : this(options.Value)
        {
        }

        public GraphClient(GraphClientOptions options = default) : base(new SocketsHttpHandler())
        {
            _options = options;
        }

        private AuthenticationHeaderValue GetAuthZHeader()
        {
            if (Regex.IsMatch(_options.ClientSecret, JwtConstants.JsonCompactSerializationRegex) || Regex.IsMatch(_options.ClientSecret, JwtConstants.JweCompactSerializationRegex))
            {
                return new AuthenticationHeaderValue("Bearer", _options.ClientSecret);
            }
            else
            {
                return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format(":{0}", _options.ClientSecret))));
            }
        }

        public async Task<HttpResponseMessage> GetPrincipalIdByGroupName(string groupName)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> ListAppRoleRequest(string principalIdOrUserPrincipalName, CancellationToken token = default)
        {
            var request = new ListAppRoleRequest(principalIdOrUserPrincipalName);
            request.Headers.Authorization ??= GetAuthZHeader();
            var response = await SendAsync(request, token);
            return response;
        }

        public async Task<HttpResponseMessage> AddAppRoleRequest(string principalId, string ResourceId, string AppRoleId, CancellationToken token = default)
        {
            var azureAppRoleAssignment = new AzureAppRoleAssignmentDto
            {
                PrincipalId = principalId,
                ResourceId = ResourceId,
                AppRoleId = AppRoleId
            };

            var request = new AddAppRoleRequest(principalId, azureAppRoleAssignment);
            request.Headers.Authorization ??= GetAuthZHeader();
            var response = await SendAsync(request, token);
            return response;
        }

        public async Task<HttpResponseMessage> RemoveAppRoleRequest(string Id, CancellationToken token = default)
        {
            var request = new RemoveAppRoleRequest(Id);
            request.Headers.Authorization ??= GetAuthZHeader();
            var response = await SendAsync(request, token);
            return response;
        }
    }
}
