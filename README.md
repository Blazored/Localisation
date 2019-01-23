# Blazored Localisation
A library to provide localisation in client-side Blazor applications

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
