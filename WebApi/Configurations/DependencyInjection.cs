using Business.Interfaces;
using Business.Services;

namespace WebApi.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBillingConsumerService, BillingConsumerService>();

            return services;
        }
    }
}
