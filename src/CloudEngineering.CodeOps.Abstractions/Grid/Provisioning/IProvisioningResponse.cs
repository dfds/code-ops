using System.Net.Http;

namespace CloudEngineering.CodeOps.Abstractions.Grid.Provisioning
{
	public interface IProvisioningResponse
	{
		HttpContent Content { get; }
	}
}
