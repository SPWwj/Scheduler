using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Scheduler.Client;
using Scheduler.Client.Utilis;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTUzMjMzQDMxMzkyZTM0MmUzMEVZM0J5K2tQVzRUdFQxVWRUbjNYcDJudTJNNU1RQ1VUeTU4WGZlMW9CSjQ9");
builder.Services.AddSingleton<SidebarState>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
