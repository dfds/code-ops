using CloudEngineering.CodeOps.Abstractions.Commands;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Cost;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Policy;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Role;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Security;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices
{
    public static class DependencyInjection
    {
        public static void AddAmazonWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Framework dependencies
            services.AddLogging();

            //Package dependencies
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFacade(configuration);
            services.AddCommandHandlers();
        }

        private static void AddFacade(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AwsFacadeOptions>(configuration.GetSection(AwsFacadeOptions.AwsFacade));

            services.AddTransient<IAwsCredentialResolver, AwsCredentialResolver>();
            services.AddTransient<IAwsClientFactory, AwsClientFactory>();
            services.AddTransient<IAwsFacade, AwsFacade>();
        }

        private static void AddCommandHandlers(this IServiceCollection services)
        {
            //CredentialProfileStoreChain
            services.AddTransient<IRequestHandler<RegisterProfileCommand, Task>, RegisterProfileCommandHandler>();
            services.AddTransient<ICommandHandler<RegisterProfileCommand, Task>, RegisterProfileCommandHandler>();
            services.AddTransient<IRequestHandler<UnregisterProfileCommand, Task>, UnregisterProfileCommandHandler>();
            services.AddTransient<ICommandHandler<UnregisterProfileCommand, Task>, UnregisterProfileCommandHandler>();

            //IAmazonCostExplorer
            services.AddTransient<ICommandHandler<GetMonthlyTotalCostCommand, IEnumerable<CostDto>>, GetMonthlyTotalCostCommandHandler>();
            services.AddTransient<IRequestHandler<GetMonthlyTotalCostCommand, IEnumerable<CostDto>>, GetMonthlyTotalCostCommandHandler>();

            //AmazonIdentityManagementServiceClient
            services.AddTransient<ICommandHandler<CreatePolicyCommand, ManagedPolicyDto>, CreatePolicyCommandHandler>();
            services.AddTransient<IRequestHandler<CreatePolicyCommand, ManagedPolicyDto>, CreatePolicyCommandHandler>();
            services.AddTransient<ICommandHandler<DeletePolicyCommand, Task>, DeletePolicyCommandHandler>();
            services.AddTransient<IRequestHandler<DeletePolicyCommand, Task>, DeletePolicyCommandHandler>();

            services.AddTransient<ICommandHandler<CreateRoleCommand, RoleDto>, CreateRoleCommandHandler>();
            services.AddTransient<IRequestHandler<CreateRoleCommand, RoleDto>, CreateRoleCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteRoleCommand, Task>, DeleteRoleCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteRoleCommand, Task>, DeleteRoleCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateRoleCommand, Task>, UpdateRoleCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateRoleCommand, Task>, UpdateRoleCommandHandler>();

            //AmazonSimpleSystemsManagementClient
            services.AddTransient<ICommandHandler<AddOrUpdateParameterCommand, ParameterDto>, AddOrUpdateParameterCommandHandler>();
            services.AddTransient<IRequestHandler<AddOrUpdateParameterCommand, ParameterDto>, AddOrUpdateParameterCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteParameterCommand, Task>, DeleteParameterCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteParameterCommand, Task>, DeleteParameterCommandHandler>();
            services.AddTransient<ICommandHandler<GetParameterCommand, ParameterDto>, GetParameterCommandHandler>();
            services.AddTransient<IRequestHandler<GetParameterCommand, ParameterDto>, GetParameterCommandHandler>();
        }
    }
}
