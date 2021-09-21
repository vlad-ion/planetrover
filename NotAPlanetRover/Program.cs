using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: false)
                .Build().GetSection("App");

            return Host.CreateDefaultBuilder(args).ConfigureServices((_, services)
                => services
                    .AddHostedService<Worker>()
                    .AddScoped<IMap>(_ => new Map(
                        width: config.GetValue<uint>("width"),
                        height: config.GetValue<uint>("height"),
                        withObstacles: config.GetValue<bool>("withObstacles")))
                    .AddScoped<IRover, Rover>()
                    .AddScoped<IRoverController, RoverController>());
        }
    }
}
