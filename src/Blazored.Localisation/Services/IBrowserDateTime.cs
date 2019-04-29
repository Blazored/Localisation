using System;

namespace Blazored.Localisation.Services
{
    public interface IBrowserDateTime
    {
        TimeZoneInfo LocalTimeZoneInfo { get; }
        DateTime Now { get; }

        string ConvertToBrowserTime(DateTime dateTime, string format = "");
    }
}