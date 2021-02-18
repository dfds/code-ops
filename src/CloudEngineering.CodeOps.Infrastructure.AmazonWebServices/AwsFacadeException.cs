using System;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices
{
    public sealed class AwsFacadeException : Exception
    {
        public AwsFacadeException()
        { }

        public AwsFacadeException(string message)
            : base(message)
        { }

        public AwsFacadeException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
