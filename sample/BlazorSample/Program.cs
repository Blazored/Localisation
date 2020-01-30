using Blazored.Localisation;
using Microsoft.AspNetCore.Blazor.Hosting;
using System.Threading.Tasks;

namespace BlazorSample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddBlazoredLocalisation();
            builder.RootComponents.Add<App>("app");

            var host = builder.Build();
            host.InitializeBlazoredLocalization();
            
            await host.RunAsync();
        }
    }
}
