using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Builder;
using System.Globalization;

namespace Blazored.Localisation
{
    public static class UseBrowserLocalisationExtension
    {
        public static void UseBlazoredLocalisation(this IComponentsApplicationBuilder app)
        {
            var jsRuntime = app.Services.GetService(typeof(IJSRuntime));
            var browserLocale = ((IJSInProcessRuntime)jsRuntime).Invoke<string>("blazoredLocalisation.getBrowserLocale");
            var culture = new CultureInfo(browserLocale);

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
