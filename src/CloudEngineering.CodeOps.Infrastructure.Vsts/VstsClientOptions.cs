using System;

namespace CloudEngineering.CodeOps.Infrastructure.Vsts
{
    public sealed class VstsClientOptions
    {
        public const string Vsts = "Vsts";

        public Uri Issuer { get; set; }

        public Uri AuthorizeService => new Uri($"{Issuer.AbsoluteUri}/oauth2/authorize");

        public Uri TokenService => new Uri($"{Issuer.AbsoluteUri}/oauth2/token");

        public Uri RedirectUri { get; set; }

        public string DefaultOrganization { get; set; } = "dfds";

        public string ClientSecret { get; set; }
    }
}
