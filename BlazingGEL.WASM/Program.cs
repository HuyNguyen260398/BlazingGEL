using BlazingGEL.WASM;
using BlazingGEL.WASM.ServiceInterfaces;
using BlazingGEL.WASM.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTQ0MjE2QDMxMzkyZTMzMmUzMElRUWUyNDVGdGVYaS9XVVV2eHBJSFFtZUh6U25JVC9NSWtFYnI5QUJLaFU9");

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Midleware
builder.Services.AddSyncfusionBlazor();

// DI Repository Services
builder.Services.AddScoped<IPostRepository, PostRepository>();

await builder.Build().RunAsync();
