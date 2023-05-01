using BlazorEcommerce.Client;
using BlazorEcommerce.Client.Services.Business;
using BlazorEcommerce.Client.Services.Business.Interfaces;
using BlazorEcommerce.Client.Services.Business.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ICategoryManagerClient, CategoryManagerClient>();

await builder.Build().RunAsync();
