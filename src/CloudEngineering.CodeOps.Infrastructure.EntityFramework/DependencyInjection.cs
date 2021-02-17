using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CloudEngineering.CodeOps.Infrastructure.EntityFramework
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediator();
            services.AddEntityFramework(configuration);
        }

        private static void AddMediator(this IServiceCollection services)
        {
            services.AddTransient<ServiceFactory>(p => p.GetService);

            services.AddTransient<IMediator>(p => new Mediator(p.GetService<ServiceFactory>()));
        }

        private static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EntityContextOptions>(configuration);
        }
    }
}
