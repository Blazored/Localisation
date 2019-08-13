# Blazored Localisation
A library to provide localisation in Blazor WebAssembly apps and time zone information in Blazor Server apps

[![Build Status](https://dev.azure.com/blazored/Localisation/_apis/build/status/Blazored.Localisation?branchName=master)](https://dev.azure.com/blazored/Localisation/_build/latest?definitionId=2&branchName=master)

![Nuget](https://img.shields.io/nuget/v/blazored.localisation.svg)

### Installing

You can install from Nuget using the following command:

`Install-Package Blazored.Localisation`

Or via the Visual Studio package manager.

### Setup

**Blazor WebAssembly**
Add the following script tag to your `index.html`.

```html
<script src="_content/Blazored.Localisation/blazored-localisation.js"></script>
```

Blazored Localisation requires the following lines added to your _startup.cs_. 

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddBlazoredLocalisation(); // This adds the IBrowserDateTimeProvider to the DI container
}

public void Configure(IComponentsApplicationBuilder app)
{
    app.UseBlazoredLocalisation(); // This adds the middleware to setup the correct Culture Info based on the users browser.
}
```

Culture is set app wide via the middleware registered in the `Configure` method above. This will set the `CultureInfo.CurrentCulture` and `CultureInfo.CurrentUICulture` based on the language settings of the clients browser. This will mean dates, times and currency should reflect what the end users browser has configured. This however does not take into account timezones. 

To get times using the correct timezone information you will need to request an instance of the `IBrowserDataTimeProvider`. Once you have this you can use the `GetInstance` method to get a `IBrowserDataTime` instance. You can use the `Now` property to get a `DateTime` instance which takes into account the users timezone. 

**
Example**

```csharp
@using System.Globalization
@inject Blazored.Localisation.Services.IBrowserDateTimeProvider browserDateTimeProvider
@page "/"

<h3>Culture Info</h3>
<p>Current Culture: <strong>@CultureInfo.CurrentUICulture.DisplayName</strong></p>
<p>Current Culture Code: <strong>@CultureInfo.CurrentCulture.Name</strong></p>
<p>Current UI Culture Code: <strong>@CultureInfo.CurrentUICulture.Name</strong></p>
<p>Current Culture Currency Symbol: <strong>@CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol</strong></p>
<p>Current Culture DateTime Pattern: <strong>@CultureInfo.CurrentUICulture.DateTimeFormat.FullDateTimePattern</strong></p>
<hr />
<h3>TimeZone Info</h3>
<p>The current time zone is: <strong>@currentTimeZone</strong></p>
<p>The current time zone offset is: <strong>@currentTimeZoneOffSet</strong></p>
<p>The current local time is: <strong>@currentLocalTime</strong></p>

@code {

    string currentTimeZone;
    TimeSpan currentTimeZoneOffSet;
    string currentLocalTime;

    protected override async Task OnInitAsync()
    {
        var browserDateTime = await browserDateTimeProvider.GetInstance();

        currentTimeZone = browserDateTime.LocalTimeZoneInfo.DisplayName;
        currentTimeZoneOffSet = browserDateTime.LocalTimeZoneInfo.GetUtcOffset(DateTime.Now);
        currentLocalTime = browserDateTime.Now.ToString();
    }

}
```

**Blazor Server**
Setting of the Culture is currently not available for server-side Blazor applications, only the `IBrowserDateTime` service is available.

Blazored Localisation requires the following lines added to your _startup.cs_.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddBlazoredLocalisation(); // This adds the IBrowserDateTimeProvider to the DI container
}
```

To get times using the correct timezone information you will need to request an instance of the `IBrowserDataTimeProvider`. Once you have this you can use the `GetInstance` method to get a `IBrowserDataTime` instance. You can use the `Now` property to get a `DateTime` instance which takes into account the users timezone. See the example below.

```csharp
@inject Blazored.Localisation.Services.IBrowserDateTimeProvider browserDateTimeProvider
@page "/"

<p>The current local time is: <strong>@currentLocalTime</strong></p>

@code {

    string currentLocalTime = "";

    protected override async Task OnAfterRenderAsync()
    {
        var browserDateTime = await browserDateTimeProvider.GetInstance();
        currentLocalTime = browserDateTime.Now.ToString();
        StateHasCahnged();
    }

}
``` 

This will set the `CultureInfo.CurrentCulture` and `CultureInfo.CurrentUICulture` for your Blazor application based on the language settings of the clients browser.
