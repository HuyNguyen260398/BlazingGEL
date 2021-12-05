using BlazingGEL.WASM;
using BlazingGEL.WASM.ServiceInterfaces;
using BlazingGEL.WASM.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// DI Repository Services
builder.Services.AddScoped<IPostRepository, PostRepository>();

await builder.Build().RunAsync();
