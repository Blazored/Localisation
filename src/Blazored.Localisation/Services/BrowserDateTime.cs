using System;
using System.Globalization;

namespace Blazored.Localisation.Services
{
    public class BrowserDateTime : IBrowserDateTime
    {
        public TimeZoneInfo LocalTimeZoneInfo { get; private set; }
        public DateTime Now => GetBrowserDateTime();

        public BrowserDateTime(TimeZoneInfo timeZoneInfo)
        {
            LocalTimeZoneInfo = timeZoneInfo;
        }

        public string ConvertToBrowserTime(DateTime dateTime, string format = "")
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                return TimeZoneInfo.ConvertTime(dateTime, LocalTimeZoneInfo)
                                   .ToString();
            }

            return TimeZoneInfo.ConvertTime(dateTime, LocalTimeZoneInfo)
                               .ToString(format, CultureInfo.CurrentCulture);
        }

        private DateTime GetBrowserDateTime()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, LocalTimeZoneInfo);
        }
    }
}
