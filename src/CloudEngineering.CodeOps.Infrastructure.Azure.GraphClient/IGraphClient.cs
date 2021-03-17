using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient
{
    public interface IGraphClient
    {
        Task<HttpResponseMessage> AddAppRoleRequest(string principalId, string ResourceId, string AppRoleId, CancellationToken token = default);

        Task<HttpResponseMessage> ListAppRoleRequest(string principalIdOrUserPrincipalName, CancellationToken token = default);

        Task<HttpResponseMessage> RemoveAppRoleRequest(string Id, CancellationToken token = default);
    }
}