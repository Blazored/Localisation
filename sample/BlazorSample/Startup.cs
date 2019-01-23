using Blazored.Localisation;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSample
{
    public class Startup
    {
        public void Configure(IBlazorApplicationBuilder app)
        {
            app.UseBlazoredLocalisation();
            app.AddComponent<App>("app");
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }
    }
}
