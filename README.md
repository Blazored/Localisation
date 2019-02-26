# Blazored Localisation
A library to provide localisation in client-side Blazor applications

[![Build Status](https://dev.azure.com/blazored/Localisation/_apis/build/status/Blazored.Localisation?branchName=master)](https://dev.azure.com/blazored/Localisation/_build/latest?definitionId=2&branchName=master)

![Nuget](https://img.shields.io/nuget/v/blazored.localisation.svg)

## Important Notice For ASP.NET Core Razor Components Apps
There is currently an issue with [ASP.NET Core Razor Components apps](https://devblogs.microsoft.com/aspnet/aspnet-core-3-preview-2/#sharing-component-libraries) (not Blazor). They are unable to import static assets from component libraries such as this one. 

You can still use this package, however, you will need to manually add the JavaScript file to your Razor Components `wwwroot` folder. Then you will need to reference it in your `index.html`.

### Installing

You can install from Nuget using the following command:

`Install-Package Blazored.Localisation`

Or via the Visual Studio package manager.

### Setup

You just need to add `app.UseBlazoredLocalisation();` in your _startup.cs_ file as per the example below.

```c#
public void Configure(IBlazorApplicationBuilder app)
{
    app.UseBlazoredLocalisation();
    app.AddComponent<App>("app");
}
``` 

This will set the `CultureInfo.CurrentCulture` and `CultureInfo.CurrentUICulture` for your Blazor application based on the language settings of the clients browser.
