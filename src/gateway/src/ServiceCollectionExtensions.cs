using ApiGateway.Services;
using Consul;

namespace ApiGateway
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterConsulServices(this IServiceCollection services, ServiceConfig serviceConfig)
        {
            if (serviceConfig == null)
            {
                throw new ArgumentNullException(nameof(serviceConfig));
            }

            var consulClient = CreateConsulClient(serviceConfig);

            services.AddSingleton(serviceConfig);
            services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();
            services.AddSingleton<IConsulClient, Consul.ConsulClient>(p => consulClient);
        }

        private static Consul.ConsulClient CreateConsulClient(ServiceConfig serviceConfig)
        {
            return new Consul.ConsulClient(config =>
            {
                config.Address = serviceConfig.ServiceDiscoveryAddress;
            });
        }
    }
}
