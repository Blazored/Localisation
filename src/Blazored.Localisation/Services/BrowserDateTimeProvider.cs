using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazored.Localisation.Services
{
    public class BrowserDateTimeProvider : IBrowserDateTimeProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private IBrowserDateTime _browserDateTime;

        public BrowserDateTimeProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<IBrowserDateTime> GetInstance()
        {
            if (_browserDateTime == null)
            {
                var timeZoneOffSet = await _jsRuntime.InvokeAsync<int>("eval", "new Date().getTimezoneOffset()");
                var browserTimeZoneIdentifier = await _jsRuntime.InvokeAsync<string>("eval", "Intl.DateTimeFormat().resolvedOptions().timeZone");
                var timeZoneIdentifier = string.IsNullOrWhiteSpace(browserTimeZoneIdentifier) ? "BrowserTZ" : browserTimeZoneIdentifier;
                var browserTimeZone = TimeZoneInfo.CreateCustomTimeZone(timeZoneIdentifier, new TimeSpan(0, 0 - timeZoneOffSet, 0), timeZoneIdentifier, timeZoneIdentifier);

                _browserDateTime = new BrowserDateTime(browserTimeZone);
            }

            return _browserDateTime;
        }
    }
}
