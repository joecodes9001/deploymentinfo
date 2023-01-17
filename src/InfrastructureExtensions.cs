using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Batshark.DeploymentInfo.Services;

namespace Batshark.DeploymentInfo
{
    public static class DeploymentInfoExtensions
    {
        /// <summary>
        /// Add all deployment info services.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddDeploymentInfoServicesAll(this IServiceCollection services, Action<DeploymentInfoOptions> options = null)
        {

            services.AddScoped<IChecksumsService, ChecksumsService>();
            services.AddScoped<IVersionService, VersionService>();
            services.AddScoped<IWhoamiService, WhoamiService>();

            if (options != null)
            {
                services.Configure(options);
            }

            return services;
        }


        /// <summary>
        /// Add Checksum Service.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddDeploymentInfoServicesChecksums(this IServiceCollection services, Action<DeploymentInfoOptions> options = null)
        {

            services.AddScoped<IChecksumsService, ChecksumsService>();
            if (options != null)
            {
                services.Configure(options);
            }


            return services;
        }

        /// <summary>
        /// Add Version Service.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddDeploymentInfoServicesVersion(this IServiceCollection services, Action<DeploymentInfoOptions> options = null)
        {

            services.AddScoped<IVersionService, VersionService>();
            if (options != null)
            {
                services.Configure(options);
            }


            return services;
        }

        /// <summary>
        /// Add Whoami service.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddDeploymentInfoServicesWhoami(this IServiceCollection services, Action<DeploymentInfoOptions> options = null)
        {

            services.AddScoped<IWhoamiService, WhoamiService>();
            if (options != null)
            {
                services.Configure(options);
            }


            return services;
        }

        /// <summary>
        /// Map all routes.
        /// </summary>
        /// <param name="endpoints"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IEndpointRouteBuilder MapDeploymentServiceInfoAll(this IEndpointRouteBuilder endpoints, Action<DeploymentInfoOptions> options = null)
        {
            endpoints.MapDeploymentServiceWhoami(options);
            endpoints.MapDeploymentServiceInfoChecksums(options);
            endpoints.MapDeploymentServiceInfoVersion(options);

            return endpoints;
        }

        /// <summary>
        /// Map Whoami route
        /// </summary>
        /// <param name="endpoints"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IEndpointRouteBuilder MapDeploymentServiceWhoami(this IEndpointRouteBuilder endpoints, Action<DeploymentInfoOptions> options = null)
        {
            var deploymentInfoOptions = new DeploymentInfoOptions();
            options?.Invoke(deploymentInfoOptions);
            endpoints.MapGet(deploymentInfoOptions.WhoamiRoute, (IWhoamiService service) =>
            {
                return service.Get();
            });

            return endpoints;
        }

        /// <summary>
        /// Map Checksums route.
        /// </summary>
        /// <param name="endpoints"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IEndpointRouteBuilder MapDeploymentServiceInfoChecksums(this IEndpointRouteBuilder endpoints, Action<DeploymentInfoOptions> options = null)
        {
            var deploymentInfoOptions = new DeploymentInfoOptions();
            options?.Invoke(deploymentInfoOptions);
            endpoints.MapGet(deploymentInfoOptions.ChecksumsRoute, (IChecksumsService service) =>
            {
                return service.GetChecksums();
            });

            return endpoints;
        }

        /// <summary>
        /// Map Version route.
        /// </summary>
        /// <param name="endpoints"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IEndpointRouteBuilder MapDeploymentServiceInfoVersion(this IEndpointRouteBuilder endpoints, Action<DeploymentInfoOptions> options = null)
        {
            var deploymentInfoOptions = new DeploymentInfoOptions();
            options?.Invoke(deploymentInfoOptions);
            endpoints.MapGet(deploymentInfoOptions.VersionRoute, (IVersionService service) =>
            {
                return service.GetVersionData();
            });

            return endpoints;
        }

    }
}