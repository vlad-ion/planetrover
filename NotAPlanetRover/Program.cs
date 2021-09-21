using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotAPlanetRover.Controllers;
using NotAPlanetRover.Models;

namespace NotAPlanetRover
{
    class Program
    {
        static Task Main(string[] args) 
            => CreateHostBuilder(args).Build().RunAsync();

        static IHostBuilder CreateHostBuilder(string[] args) 
            => Host.CreateDefaultBuilder(args).ConfigureServices((_, services)
                => services.AddHostedService<Worker>()
                    .AddScoped<IMap, Map>()
                    .AddScoped<IRover, Rover>()
                    .AddScoped<IRoverController, RoverController>());
    }
}
