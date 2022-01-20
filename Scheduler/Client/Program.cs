using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Scheduler.Client;
using Scheduler.Client.FlappyBird.Data;
using Scheduler.Client.Utilis;
using Syncfusion.Blazor;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTY3OTQ1QDMxMzkyZTM0MmUzMGhacFVya2s1aURuRk5XR2p1b3I1YUFNK0RXUnp2SEc1R3NWYUhaOUMxdDg9");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<MenuItemState>();
builder.Services.AddSingleton<Universe>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
