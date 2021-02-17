using System;
using CloudEngineering.CodeOps.Abstractions.Events;

namespace CloudEngineering.CodeOps.Abstractions.Grid.Provisioning
{
	public interface IProvisioningBroker : IProvisioningHandler, IEventHandler<IProvisioningEvent>
	{
	}
}
