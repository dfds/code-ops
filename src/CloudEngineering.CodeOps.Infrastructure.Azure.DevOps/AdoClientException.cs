using System;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.DevOps
{
    public sealed class AdoClientException : Exception
    {
        public AdoClientException()
        { }

        public AdoClientException(string message)
            : base(message)
        { }

        public AdoClientException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
