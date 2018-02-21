using Microsoft.Extensions.DependencyInjection;
using RP.Service;

namespace RP.WebApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            // and a lot more Services

            return services;
        }
    }
}