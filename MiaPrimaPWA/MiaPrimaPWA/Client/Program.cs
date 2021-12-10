using MiaPrimaPWA.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using TG.Blazor.IndexedDB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddIndexedDB(dbStore =>
{
    dbStore.DbName = "CorsoBlazor";
    dbStore.Version = 1;

    dbStore.Stores.Add(new StoreSchema
    {
         Name = "People",
         PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto=true},
         Indexes = new List<IndexSpec>
         {
             new IndexSpec { Name= "name", KeyPath = "name", Auto= false},
             new IndexSpec { Name= "count", KeyPath = "count", Auto= false}
         }
    });
});

await builder.Build().RunAsync();
