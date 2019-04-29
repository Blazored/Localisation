using Blazored.Localisation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blazored.Localisation
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazoredLocalisation(this IServiceCollection services)
        {
            return services.AddScoped<IBrowserDateTimeProvider, BrowserDateTimeProvider>();
        }
    }
}
