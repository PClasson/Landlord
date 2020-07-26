using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.IndexedDB.Framework;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Landlord
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IIndexedDbFactory, IndexedDbFactory>();
            builder.Services.AddMatToaster(config =>
                {
                    config.Position = MatToastPosition.BottomRight;
                    config.PreventDuplicates = true;
                    config.NewestOnTop = true;
                    config.ShowCloseButton = true;
                    config.MaximumOpacity = 100;
                    config.VisibleStateDuration = 3000;
                    config.ShowProgressBar = false;
                });

            await builder.Build().RunAsync();
        }
    }
}
