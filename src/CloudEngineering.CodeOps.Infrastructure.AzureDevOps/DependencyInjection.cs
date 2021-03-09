﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CloudEngineering.CodeOps.Infrastructure.AzureDevOps
{
    public static class DependencyInjection
    {
        public static void AddAzureDevOps(this IServiceCollection services, IConfiguration configuration)
        {
            //External dependencies
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Package dependencies
            services.Configure<AdoClientOptions>(configuration.GetSection(AdoClientOptions.AdoClient));

            services.AddTransient<IAdoClient, AdoClient>();
        }
    }
}
