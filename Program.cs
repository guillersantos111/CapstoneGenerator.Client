using Blazored.LocalStorage;
using CapstoneGenerator.Client;
using CapstoneGenerator.Client.Services;
using CapstoneGenerator.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<ICapstoneService, CapstoneService>();
builder.Services.AddScoped<IGeneratorService, GeneratorService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5087") });

builder.Services.AddMudServices();
builder.Services.AddOptions();



builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();