using System.Reflection;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp1;
using BlazorApp1.Clients;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient(nameof(PhrasesApiClient), config =>
{
    var url = builder.Configuration["Apis:PhrasesApi:BaseUrl"];
    if (string.IsNullOrEmpty(url))
        throw new ArgumentNullException(nameof(PhrasesApiClient));
    
    config.BaseAddress = new Uri(url);
});

builder.Services.AddHttpClient(nameof(ImagesApiClient), config =>
{
    var url = builder.Configuration["Apis:ImagesApi:BaseUrl"];
    if (string.IsNullOrEmpty(url))
        throw new ArgumentNullException(nameof(ImagesApiClient));
    
    config.BaseAddress = new Uri(url);
});

builder.Services.AddTransient<PhrasesApiClient>();
builder.Services.AddTransient<ImagesApiClient>();

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();