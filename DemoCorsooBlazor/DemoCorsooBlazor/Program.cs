using DemoCorsoBlazor.Library.Interfaces;
using DemoCorsooBlazor;
using DemoCorsooBlazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Http;
using Polly;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services
.AddHttpClient("reqres", client =>
{
    client.BaseAddress = new Uri("https://reqres.in/");
})
.AddTransientHttpErrorPolicy( x => x.WaitAndRetryAsync(
    new[] { TimeSpan.FromSeconds(2), 
            TimeSpan.FromSeconds(10), 
            TimeSpan.FromSeconds(30)}) );

builder.Services.AddScoped<IOrderData, StaticOrdersData>();
builder.Services.AddScoped<IReqResData, ReqResService>();


await builder.Build().RunAsync();
