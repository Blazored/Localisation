using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.JSInterop;
using System.Globalization;

namespace Blazored.Localisation
{
    public static class UseBrowserLocalisationExtension
    {
        public static void UseBlazoredLocalisation(this IBlazorApplicationBuilder app)
        {
            var browserLocale = ((IJSInProcessRuntime)JSRuntime.Current).Invoke<string>("Blazored.Localisation.GetBrowserLocale");
            var culture = new CultureInfo(browserLocale);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
    }
}
