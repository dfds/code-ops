using System;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts
{
    public sealed class VstsClientException : Exception
    {
        public VstsClientException()
        { }

        public VstsClientException(string message)
            : base(message)
        { }

        public VstsClientException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
