using System;

namespace CloudEngineering.CodeOps.Infrastructure.EntityFramework
{
    public sealed class EntityContextException : Exception
    {
        public EntityContextException()
        { }

        public EntityContextException(string message)
            : base(message)
        { }

        public EntityContextException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
