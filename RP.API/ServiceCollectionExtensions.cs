using Microsoft.Extensions.DependencyInjection;
using RP.Service;

namespace RP.API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();

            return services;
        }
    }
}