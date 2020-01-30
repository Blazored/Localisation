using Microsoft.JSInterop;
using System.Globalization;
using Microsoft.AspNetCore.Blazor.Hosting;

namespace Blazored.Localisation
{
    public static class WebAssemblyHostExtensions
    {
        public static void InitializeBlazoredLocalization(this WebAssemblyHost app)
        {
            var jsRuntime = app.Services.GetService(typeof(IJSRuntime));
            var browserLocale = ((IJSInProcessRuntime)jsRuntime).Invoke<string>("blazoredLocalisation.getBrowserLocale");
            var culture = new CultureInfo(browserLocale);

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
