using System;

namespace CloudEngineering.CodeOps.Abstractions.Grid
{
    public interface IGridActor
    {
        Guid Id { get; }

        GridActorType ActorType { get; }
    }
}
