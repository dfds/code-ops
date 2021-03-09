using CloudEngineering.CodeOps.Abstractions.Commands;

namespace CloudEngineering.CodeOps.Abstractions.Grid.Provisioning
{
    public interface IProvisioningHandler : ICommandHandler<IProvisioningRequest, IProvisioningResponse>, IGridActor
    {

    }
}
